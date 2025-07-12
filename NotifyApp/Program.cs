using NotifyApp.Core;
using NotifyApp.Services;

class Program
{
    static void Main(string[] args)
    {
        NotificationService.ConfigureEmailSender(new SmtpEmailSender
        ( "your_email@gmail.com", // Oz gmail addressinizi daxil edin.
          "your_app_password"     // Gmail ucun App Password daxil edin(README faylinda etrafli izah olunub).
        ));

        IAuthenticationService authService = new AuthenticationService();
        SystemManager manager = new SystemManager(authService);
        manager.Run();
    }
}