using NotifyApp.Models;

namespace NotifyApp.Services;
public static class FakeDataService
{
    public static List<User> Users { get; private set; } = new();
    public static List<Post> Posts { get; private set; } = new();
    public static void Seed()
    {
        var admin = Admin.Instance;
        admin.Username = "admin";
        admin.Email = "rahimovabanovsha@gmail.com";
        admin.Password = "admin123";

        var post1 = new Post
        {
            Content = "Welcome to NotifyApp! This is your first post."
        };

        var post2 = new Post
        {
            Content = "Stay updated with our latest news."
        };

        admin.Posts.Add(post1);
        admin.Posts.Add(post2);

        var user1 = new User
        {
            Name = "Banovsha",
            Surname = "Rahimova",
            Age = 20,
            Email = "rahimovabanovsha@gmail.com",
            Password = "banovsha123"
        };

        var user2 = new User
        {
            Name = "Kamal",
            Surname = "Mammadov",
            Age = 22,
            Email = "kamalm@gmail.com",
            Password = "kamal123"
        };

        Users.Add(user1);
        Users.Add(user2);

        Posts.Add(post1);
        Posts.Add(post2);
        //NotificationService.SendNotification(user1, "New user joined: Banovsha Rahimova");
    }
}