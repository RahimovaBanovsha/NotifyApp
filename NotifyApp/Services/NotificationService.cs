using NotifyApp.Models;

namespace NotifyApp.Services;

public static class NotificationService
{
    private static INotificationSender? _emailSender;

    public static void ConfigureEmailSender(INotificationSender emailSender)
    {
        _emailSender = emailSender;
    }

    public static void SendNotification(User fromUser, string text)
    {

        var notification = new Notification
        {
            Id = Guid.NewGuid(),
            Text = text,
            DateTime = DateTime.Now,
            FromUser = $"{fromUser.Name} {fromUser.Surname}"

        };

        Admin.Instance.Notifications.Add(notification);

        _emailSender?.Send(Admin.Instance.Email, "New Notification", text);

    }
}