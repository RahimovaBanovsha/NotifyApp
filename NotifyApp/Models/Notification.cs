namespace NotifyApp.Models;

public class Notification
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Text { get; set; } = default!;
    public DateTime DateTime { get; set; } = DateTime.Now;
    public string FromUser { get; set; } = default!;

}
