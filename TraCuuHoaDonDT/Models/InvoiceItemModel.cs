
using System;
using System.Collections.Generic;


namespace TraCuuHoaDonDT.Models;

public partial class InvoiceItemModel
{
    public string nbmst { get; set; }
    public double? khmshdon { get; set; }
    public string khhdon { get; set; }
    public double? shdon { get; set; }
    public string cqt { get; set; }

    //chu y loai tru cac list luc gan value tu dong

    public List<ThongTinKhacModel> cttkhac { get; set; }
    public List<ItemHdhhdvuModel> hdhhdvu { get; set; }
    public List<ThongTinKhacModel> nbttkhac { get; set; }
    public List<ThongTinKhacModel> nmttkhac { get; set; }
    public List<ThongTinKhacModel> thttlphi { get; set; }
    public List<ThttltsuatModel> thttltsuat { get; set; }
    public List<ThongTinKhacModel> ttkhac { get; set; }
    public List<ThongTinKhacModel> ttttkhac { get; set; }
    //chu y loai tru cac list luc gan value tu dong
    public string dvtte { get; set; }
    public string hdon { get; set; }
    public string hsgcma { get; set; }
    public string hsgoc { get; set; }
    public double? hthdon { get; set; }
    public double? htttoan { get; set; }
    public string id { get; set; }
    public string idtbao { get; set; }
    public string khdon { get; set; }
    public string khhdgoc { get; set; }
    public string khmshdgoc { get; set; }
    public string lhdgoc { get; set; }
    public string mhdon { get; set; }
    public string mtdiep { get; set; }
    public string mtdtchieu { get; set; }
    public string nbdchi { get; set; }
    public string nbhdktngay { get; set; }
    public string nbhdktso { get; set; }
    public string nbhdso { get; set; }
    public string nblddnbo { get; set; }
    public string nbptvchuyen { get; set; }
    public string nbstkhoan { get; set; }
    public string nbten { get; set; }
    public string nbtnhang { get; set; }
    public string nbtnvchuyen { get; set; }

    public DateTime? ncma { get; set; }
    public DateTime? ncnhat { get; set; }
    public string ngcnhat { get; set; }
    public DateTime? nky { get; set; }
    public string nmdchi { get; set; }
    public string nmmst { get; set; }
    public string nmstkhoan { get; set; }
    public string nmten { get; set; }
    public string nmtnhang { get; set; }
    public string nmtnmua { get; set; }

    public DateTime? ntao { get; set; }
    public DateTime? ntnhan { get; set; }
    public string pban { get; set; }
    public double? ptgui { get; set; }
    public string shdgoc { get; set; }
    public double? tchat { get; set; }
    public DateTime? tdlap { get; set; }
    public double? tgia { get; set; }
    public double? tgtcthue { get; set; }
    public double? tgtthue { get; set; }
    public string tgtttbchu { get; set; }
    public double? tgtttbso { get; set; }
    public string thdon { get; set; }
    public double? thlap { get; set; }

    public string tlhdon { get; set; }
    public double? ttcktmai { get; set; }
    public double? tthai { get; set; }

    public double? tttbao { get; set; }

    public double? ttxly { get; set; }
    public string tvandnkntt { get; set; }
    public string mhso { get; set; }
    public double? ladhddt { get; set; }
    public string mkhang { get; set; }
    public string nbsdthoai { get; set; }
    public string nbdctdtu { get; set; }
    public string nbfax { get; set; }
    public string nbwebsite { get; set; }
    //public string nbcks { get; set; }
    public string nmsdthoai { get; set; }
    public string nmdctdtu { get; set; }
    public string nmcmnd { get; set; }
    public string nmcks { get; set; }
    public double? bhphap { get; set; }
    public string hddunlap { get; set; }
    public string gchdgoc { get; set; }
    public DateTime? tbhgtngay { get; set; }
    public string bhpldo { get; set; }
    public string bhpcbo { get; set; }
    public string bhpngay { get; set; }
    public string tdlhdgoc { get; set; }
    public string tgtphi { get; set; }
    public string unhiem { get; set; }
    public string mstdvnunlhdon { get; set; }
    public string tdvnunlhdon { get; set; }
    public string nbmdvqhnsach { get; set; }
    public string nbsqdinh { get; set; }
    public string nbncqdinh { get; set; }
    public string nbcqcqdinh { get; set; }
    public string nbhtban { get; set; }
    public string nmmdvqhnsach { get; set; }
    public string nmddvchden { get; set; }
    public string nmtgvchdtu { get; set; }
    public string nmtgvchdden { get; set; }
    public string nbtnban { get; set; }
    public string dcdvnunlhdon { get; set; }
    public string dksbke { get; set; }
    public string dknlbke { get; set; }
    public string thtttoan { get; set; }
    public string msttcgp { get; set; }
    //public string cqtcks { get; set; }
    public string gchu { get; set; }
    public string kqcht { get; set; }
    public string hdntgia { get; set; }
    public string tgtkcthue { get; set; }
    public string tgtkhac { get; set; }
    public string nmshchieu { get; set; }
    public string nmnchchieu { get; set; }
    public string nmnhhhchieu { get; set; }
    public string nmqtich { get; set; }
    public string ktkhthue { get; set; }

    public string qrcode { get; set; }
    public string ttmstten { get; set; }
    public string ladhddtten { get; set; }
    public string hdxkhau { get; set; }
    public string hdxkptquan { get; set; }
    public string hdgktkhthue { get; set; }
    public string hdonLquans { get; set; }
    public bool tthdclquan { get; set; }
    public string pdndungs { get; set; }
    public string hdtbssrses { get; set; }
    public string hdTrung { get; set; }
    public string isHDTrung { get; set; }


    /// <summary>
    /// LinkQ custom field: Kiểm tra là HD mua vào hay bán ra
    /// </summary>
    public bool isSold { get; set; }
}

public class ItemHdhhdvuModel
{
    public string idhdon { get; set; }
    public string id { get; set; }
    public double? dgia { get; set; }
    public string dvtinh { get; set; }
    public string ltsuat { get; set; }
    public double? sluong { get; set; } = 0;
    public string stbchu { get; set; }
    public double? stckhau { get; set; } = 0;
    public double? stt { get; set; }
    public double? tchat { get; set; }
    public string ten { get; set; }
    public string thtcthue { get; set; }
    public double? thtien { get; set; } = 0;
    public double? tlckhau { get; set; } = 0;
    public double? tsuat { get; set; } = 0;
    public string tthue { get; set; }
    public double? sxep { get; set; }
    public List<ThongTinKhacModel> ttkhac { get; set; }
    public string dvtte { get; set; }
    public double? tgia { get; set; } = 1;
}

public class ThongTinKhacModel
{
    public string ttruong { get; set; }
    public string kdlieu { get; set; }
    public string dlieu { get; set; }
}

public class ThttltsuatModel
{
    public string tsuat { get; set; }
    public double? thtien { get; set; }
    public double? tthue { get; set; }
    public string gttsuat { get; set; }
}
