namespace NotifyApp.Models;
public class Post
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Content { get; set; } = default!;
    public DateTime CreationDateTime { get; set; } = DateTime.Now;
    public List<string> ViewHistory { get; set; } = new();
    public List<string> LikeHistory { get; set; } = new();

    public int LikeCount { get; set; } = 0;
    public int ViewCount { get; set; } = 0;

    public void AddView() => ViewCount++;
    public void AddLike() => LikeCount++;

}
