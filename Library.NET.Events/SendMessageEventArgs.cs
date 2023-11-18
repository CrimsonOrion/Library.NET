namespace Library.NET.Events;
public class SendMessageEventArgs(string message) : EventArgs
{
    public string Message { get; set; } = message;
}