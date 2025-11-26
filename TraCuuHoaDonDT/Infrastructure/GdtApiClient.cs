using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using TraCuuHoaDonDT.Models;

namespace TraCuuHoaDonDT.Infrastructure
{
    public class GdtApiClient
    {
        private readonly HttpClient _http;


        public GdtApiClient()
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri("https://hoadondientu.gdt.gov.vn:30000"),
                Timeout = TimeSpan.FromSeconds(10)
            };

            _http.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //Captcha
        public CaptchaModel GetCaptcha()
        {
            var json = _http.GetStringAsync("/captcha").Result;
            return JsonConvert.DeserializeObject<CaptchaModel>(json);
        }

        //Đăng nhập
        public AuthenticateResponseModel Login(AuthenticateRequestModel model)
        {
            string body = JsonConvert.SerializeObject(model);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var resp = _http.PostAsync("/security-taxpayer/authenticate", content).Result;
            resp.EnsureSuccessStatusCode();

            var json = resp.Content.ReadAsStringAsync().Result;

            var data = JsonConvert.DeserializeObject<AuthenticateResponseModel>(json);

            //Lưu token
            if (!string.IsNullOrEmpty(data?.token))
            {
                AppState.token = data.token;

                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", AppState.token);
            }


            return data;
        }

        //Lọc hóa đơn
        public async Task<InvoiceResponseModel> GetInvoicesPagingAsync(
                                                InvoiceSearchModel searchModel,
                                                string state = "",
                                                int size = 100,
                                                string sort = "tdlap:desc,khmshdon:asc,shdon:desc")
        {
            var query = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);
            query.Add("sort", sort);
            query.Add("size", size.ToString());
            query.Add("search", searchModel.ToString());

            if (!string.IsNullOrEmpty(state))
            {
                query.Add("state", state);
            }

            string endpoint = $"/{(searchModel.mayTinhTien ? "sco-query" : "query")}/invoices/{(searchModel.sold ? "sold" : "purchase")}?{query}";
            
            _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", AppState.token);

            var resp = await _http.GetAsync(endpoint);
            resp.EnsureSuccessStatusCode();

            string json = await resp.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<InvoiceResponseModel>(json);

            return model;
        }


        //XuatFile
        public async Task<byte[]> ExportInvoiceXmlAsync(bool mayTinhTien, string nbmst, string khhdon, string shdon, string khmshdon)
        {
            string endpoint = $"/{(mayTinhTien ? "sco-query" : "query")}/invoices/export-xml?nbmst={nbmst}&khhdon={khhdon}&shdon={shdon}&khmshdon={khmshdon}";

            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", AppState.token);

            var resp = await _http.GetAsync(endpoint);

            resp.EnsureSuccessStatusCode();

            return await resp.Content.ReadAsByteArrayAsync();
        }


    }
}
