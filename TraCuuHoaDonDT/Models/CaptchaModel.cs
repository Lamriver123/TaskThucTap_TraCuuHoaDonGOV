
namespace TraCuuHoaDonDT.Models;

public partial class CaptchaModel
{
    /// <summary>
    /// Get or set content
    /// </summary>
    public string content { get; set; }

    /// <summary>
    /// Get or set key
    /// </summary>
    public string key { get; set; }

    /// <summary>
    ///  Get or set message
    /// </summary>
    public string message {  get; set; }

    /// <summary>
    /// Get or set message
    /// This is a Url of Captcha
    /// </summary>
    public string path {  get; set; }
}
