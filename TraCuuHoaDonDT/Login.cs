using SkiaSharp;
using System.Text;
using TraCuuHoaDonDT.Models;
using Svg.Skia;
using TraCuuHoaDonDT.Infrastructure;
namespace TraCuuHoaDonDT
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            LoadCaptchaToPictureBox();
        }
        private readonly GdtApiClient _api = new GdtApiClient();
        private AuthenticateRequestModel _authenticateRequestModel = new AuthenticateRequestModel();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(txtCaptcha.Text.Trim()!="" && txtTenDangNhap.Text.Trim()!="" && txtMatKhau.Text.Trim() != "")
            {
                btnDangNhap.Enabled = false;

                _authenticateRequestModel.username = txtTenDangNhap.Text;
                _authenticateRequestModel.password = txtMatKhau.Text;
                _authenticateRequestModel.cvalue = txtCaptcha.Text;
                try
                {
                    var auth = _api.Login(_authenticateRequestModel);

                    if (auth != null)
                    {
                        this.Hide();
                        FMain fMain = new FMain();
                        fMain.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }
        public Image SvgToBitmap(string svgContent, int width, int height)
        {
            var svg = new Svg.Skia.SKSvg();
            svg.FromSvg(svgContent);

            using var bmp = new SKBitmap(width, height);
            using var canvas = new SKCanvas(bmp);

            canvas.Clear(SKColors.White);
            canvas.DrawPicture(svg.Picture);

            using var img = SKImage.FromBitmap(bmp);
            using var data = img.Encode(SKEncodedImageFormat.Png, 100);
            using var ms = new MemoryStream(data.ToArray());

            return Image.FromStream(ms);
        }
        public void LoadCaptchaToPictureBox()
        {
            try
            {
                var captcha = _api.GetCaptcha();
                string svgContent = captcha.content;


                int width = picCaptcha.Width;
                int height = picCaptcha.Height;
                picCaptcha.Image = SvgToBitmap(svgContent, width, height);
                _authenticateRequestModel.ckey = captcha.key;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi"+ ex);
            }
            
        }



        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadCaptchaToPictureBox();
        }

        
    }
}
