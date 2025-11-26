

namespace TraCuuHoaDonDT.Models;
public partial class AuthenticateRequestModel
{
    /// <summary>
    /// Gets or sets a username
    /// </summary>
    public string username {  get; set; }

    /// <summary>
    /// Gets or sets a password
    /// </summary>
    public string password { get; set; }

    /// <summary>
    /// Gets or sets a key
    /// This is a captcha key get from response
    /// </summary>
    public string ckey {  get; set; }

    /// <summary>
    /// Gets or sets a cvalue
    /// This is a captcha value get from response
    /// </summary>
    public string cvalue {  get; set; }
}
