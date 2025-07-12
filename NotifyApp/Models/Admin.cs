using NotifyApp.Utils;

namespace NotifyApp.Models;

// Admin classi Singleton Creational Design Pattern ile yaradilib.
// Bu o demekdir ki, proqram boyunca yalniz bir eded Admin obyekti olacaq.
public class Admin
{
    public static Admin Instance { get; } = new Admin();
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public List<Post> Posts { get; private set; } = new();
    public List<Notification> Notifications { get; set; } = new();

    // Bu constructor private olaraq teyin edilir ki, xaricden
    // new Admin() ile instance yaratmaq mumkun olmasin.
    // Singleton Design Pattern-in esas serti!
    private Admin() { }

}