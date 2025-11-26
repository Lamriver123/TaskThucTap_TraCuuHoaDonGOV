
namespace TraCuuHoaDonDT.Models;

/// <summary>
///  Params query string get invoices form TCT
/// </summary>
public partial class InvoiceSearchModel
{
    /// <summary>
    /// Get or set thời gian lập => Ngày bắt đầu lọc. Format string dd/MM/yyyy
    /// </summary>
    public string tdlapGe { get; set; }

    /// <summary>
    /// Get or set thời gian lập => Ngày kết thúc lọc. Format string dd/MM/yyyy
    /// </summary>
    public string tdlapLe { get; set; }

    /// <summary>
    /// Trạng thái xử lý
    /// Value: 
    /// <value>5 or none: đã cấp mã hoá đơn => Mặc định. Hóa đơn đầu ra sẽ có giá trị này để get all</value>
    /// 6: Tổng cục thuế đã nhận=> không mã => Hóa đơn đầu vào
    /// 8: Tổng cục thuế đã nhận từ máy tính tiền => Hóa đơn đầu vào
    /// </summary>
    public string ttxly { get; set; }

    /// <summary>
    /// Mã số thuế
    /// <value>Hóa đơn đầu ra (sold): Mã số thuế hiện tại của doanh nghiệp(username)</value>
    /// <value>Hóa đơn đầu vào (purchase): Mã số thuế là khách hàng của doanh nghiệp</value>
    /// </summary>
    public string mst { get; set; }

    /// <summary>
    /// Số hóa đơn
    /// </summary>
    public string shdon { get; set; }

    /// <summary>
    /// Nhà cung cấp
    /// </summary>
    public string nmcccd { get; set; }

    /// <summary>
    /// Là hóa đơn đầu vào hay đầu ra
    /// <value>true: đầu vào(default), false: đầu ra</value>
    /// </summary>
    public bool sold { get; set; } = true;

    /// <summary>
    /// trường hợp cho máy tính tiền
    /// </summary>
    public bool mayTinhTien { get; set; }

    /// <summary>
    /// override 
    /// </summary>
    /// <returns>Search QueryString</returns>
    public override string ToString()
    {
        string search = $"tdlap=ge={tdlapGe}T00:00:00;tdlap=le={tdlapLe}T23:59:59";

        if (!string.IsNullOrEmpty(ttxly))
            search += $";ttxly=={ttxly}";

        if (!string.IsNullOrEmpty(shdon))
            search += $";shdon=={shdon}";

        if (!string.IsNullOrEmpty(nmcccd))
            search += $";nmcccd=={nmcccd}";

        return search;
    }

}
