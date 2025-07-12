namespace NotifyApp.Services;

public interface INotificationSender
{
    void Send(string toEmail, string subject, string message);

}