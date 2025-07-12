using System.Net;
using System.Net.Mail;

namespace NotifyApp.Services;
public class SmtpEmailSender : INotificationSender
{
    private readonly string _fromEmail;
    // DIQQET: Asagidaki password real istifade ucun Google App Password olmalidir!
    private readonly string _appPassword;

    public SmtpEmailSender(string fromEmail, string appPassword)
    {
        _fromEmail = fromEmail;
        _appPassword = appPassword;
    }

    public void Send(string toEmail, string subject, string body)
    {
        MailMessage message = new MailMessage();
        message.From = new MailAddress(_fromEmail);
        message.To.Add(toEmail);
        message.Subject = subject;
        // Content:
        message.Body = body;

        // SMTP server ile connection qurulur:
        // 587 portu TLS ile tehlukesiz email gondermek ucun istifade olunur:
        SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential(_fromEmail, _appPassword),
            // Enable Secure Sockets Layer:
            // Tehlukesizlik ucun:
            EnableSsl = true
        /*Komputerimizden SMTP servere(meselen, gmail.com) gonderilen melumatlar
        sifrelenmis sekilde oturulur.Bu, kimse araya girib e-mail password ve
        mesaji oxuya bilmesin deye vacibdir. Email serverleri SSL olmayan
        mesajlari qebul etmir.*/

        };

        try
        {
            client.Send(message); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Email error: {ex.Message}");
        }
    }
}