namespace Library.NET.Events;
public class SendMessageEventArgs : EventArgs
{
    public string Message { get; set; }
    public SendMessageEventArgs(string message)
    {
        Message = message;
    }
}