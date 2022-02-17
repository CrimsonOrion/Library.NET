namespace Library.NET.Mailer.Models;
public class ResponseModel
{
    private bool _successful;

    public IEnumerable<string> ErrorMessages { get; set; }
    public string MessageId { get; set; }
    public bool SetSuccessful { set => _successful = value; }
    public bool IsSuccessful => _successful;
}