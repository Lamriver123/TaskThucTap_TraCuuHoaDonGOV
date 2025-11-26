using System.Text;
using System.Web;

namespace TraCuuHoaDonDT.Models;

public class InvoiceDetailFilterModel
{
    /// <summary>
    /// Mã số thuế
    /// Value: Lấy mã số thuế hiện tại nếu là HD đầu ra. Or Lấy Mã số thuế từ InvoceItem
    /// </summary>
    public string nbmst { get; set; }

    /// <summary>
    /// Ký hiệu hóa đơn
    /// </summary>
    public string khhdon { get; set; }

    /// <summary>
    ///  Ký hiệu số (mẫu) hóa đơn
    /// </summary>
    public string khmshdon { get; set; }

    /// <summary>
    /// Số hóa đơn
    /// </summary>
    public string shdon { get; set; }

    /// <summary>
    /// trường hợp cho máy tính tiền
    /// </summary>
    public bool mayTinhTien { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Filter QueryString</returns>
    public override string ToString()
    {
        var query = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);
        query.Add(nameof(nbmst), nbmst);
        query.Add(nameof(khhdon), khhdon);
        query.Add(nameof(khmshdon), khmshdon);
        query.Add(nameof(shdon), shdon);
        return query.ToString();
    }
}
