namespace Library.NET.Events;

public interface ISendMessageEvent
{
    event OnSendMessageHandler SentMessageEvent;

    void OnSendMessageEvent(SendMessageEventArgs e);
}