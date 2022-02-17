namespace Library.NET.Mailer.Models;
public class EmailOptionsModel
{
    public AddressModel FromAddress { get; set; }
    public AddressModel ReplyToAddress { get; set; }
    public IList<AddressModel> ToAddresses { get; set; } = new List<AddressModel>();
    public IList<AddressModel> CcAddresses { get; set; } = new List<AddressModel>();
    public IList<AddressModel> BccAddresses { get; set; } = new List<AddressModel>();
    public IList<FileInfo> Attachments { get; set; } = new List<FileInfo>();
    public string Subject { get; set; }
    public string Body { get; set; }
    public string Template { get; set; }
    public bool IsBodyHTML { get; set; } = false;
}