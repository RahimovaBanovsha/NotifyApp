using NotifyApp.Models;
using NotifyApp.Services;

namespace NotifyApp.Menus;
public class AdminMenu
{
    private readonly Admin _admin;

    public AdminMenu(Admin admin)
    {
        _admin = admin;
    }

    public void Run()
    {
        while (true)
        {

            Console.WriteLine("\n--- ADMIN MENU ---");
            Console.WriteLine("1. View All Posts");
            Console.WriteLine("2. View Notifications");
            Console.WriteLine("3. Create New Post");
            Console.WriteLine("4. View User Activity Statistics");
            Console.WriteLine("0. Logout");

            Console.Write("Choose an option: ");
            string option = Console.ReadLine()?.Trim() ?? "";

            switch (option)
            {
                case "1":
                    ViewAllPosts();
                    break;
                case "2":
                    ViewAllNotifications();
                    break;
                case "3":
                    CreateNewPost();
                    break;
                case "4":
                    ViewUserActivityStatistics();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
        
    private void ViewAllPosts()
    {
        Console.WriteLine("\n--- ALL POSTS ---");
        foreach (var post in FakeDataService.Posts) 
        {
            Console.WriteLine($"ID: {post.Id} | Views: {post.ViewCount} | Likes: {post.LikeCount}");
            Console.WriteLine($"Content: {post.Content}");
            Console.WriteLine("----------------------------------");
        }
    }

    private void ViewAllNotifications()
    {
        Console.WriteLine("\n--- NOTIFICATIONS ---");
        if (_admin.Notifications.Count == 0)
        {
            Console.WriteLine("No notifications.");
            // yalniz ViewAllNotifications() methodundan cixir:
            return;
            // Yeni proqram dayanmir, davam edir ve admin basqa secimlere kece bilir. 
        }

        foreach (var notification in _admin.Notifications.OrderByDescending(n=>n.DateTime))
        {
            Console.WriteLine($"From: {notification.FromUser}");
            Console.WriteLine($"Message: {notification.Text}");
            Console.WriteLine($"At: {notification.DateTime}");
            Console.WriteLine("-----------------------------");
        }

    }

    private void CreateNewPost()
    {
        Console.WriteLine("\n--- CREATE NEW POST ---");

        Console.Write("Enter post content: ");
        string content = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(content))
        {
            Console.WriteLine("Post content cannot be empty.");
            return;
        }

        var post = new Post
        {
            Content = content,
            CreationDateTime = DateTime.Now,
            ViewCount = 0,
            LikeCount = 0
        };

        FakeDataService.Posts.Add(post);
        Console.WriteLine("Post created successfully.");

    }

    private void ViewUserActivityStatistics()
    {
        Console.WriteLine("\n--- USER ACTIVITY STATISTICS ---");
        if (FakeDataService.Users.Count == 0)
        {
            Console.WriteLine("No users found!");
            return;
        }

        foreach (var user in FakeDataService.Users)
        {
            var viewedPosts = FakeDataService.Posts
                .Where(p => p.ViewHistory.Contains(user.Email)).ToList();

            var likedPosts = FakeDataService.Posts
                .Where(p => p.LikeHistory.Contains(user.Email)).ToList();

            Console.WriteLine($"User: {user.Name} {user.Surname} ({user.Email})");
            Console.WriteLine($"Viewed Posts: {viewedPosts.Count} | Liked Posts: {likedPosts.Count}");

            if (viewedPosts.Any())
            {
                Console.WriteLine("  Viewed Post IDs:");

                foreach (var post in viewedPosts)
                    Console.WriteLine($"    - {post.Id} | Content: {post.Content.Substring(0, Math.Min(30, post.Content.Length))}...");
            }

            if (likedPosts.Any())
            {
                Console.WriteLine("  Liked Post IDs:");

                foreach (var post in likedPosts)
                    Console.WriteLine($"    - {post.Id} | Content: {post.Content.Substring(0, Math.Min(30, post.Content.Length))}...");
            }

            Console.WriteLine("-----------------------------------");
        }
    }
}