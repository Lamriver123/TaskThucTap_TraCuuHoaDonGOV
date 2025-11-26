
using System.Collections.Generic;

namespace TraCuuHoaDonDT.Models;

public partial class InvoiceResponseModel
{
    /// <summary>
    /// Header data
    /// </summary>
    public List<InvoiceItemModel> datas { get; set; }
    /// <summary>
    /// Total Item
    /// </summary>
    public int total { get; set; }
    /// <summary>
    /// Trạng thái phân trang
    /// </summary>
    public string state { get; set; }

    /// <summary>
    /// Thời gian (seconds) request tiếp theo
    /// </summary>
    public int time { get; set; }
}
