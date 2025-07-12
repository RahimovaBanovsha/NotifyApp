using NotifyApp.Models;
using NotifyApp.Services;
using System;
using System.Linq;

namespace NotifyApp.Menus;
public class UserMenu
{
    private readonly User _user;

    public UserMenu(User user)
    {
        _user = user;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n--- USER MENU ---");
            Console.WriteLine("1. Show All Posts");
            Console.WriteLine("2. View Post by ID");
            Console.WriteLine("3. Like Post by ID");
            Console.WriteLine("0. Logout");

            Console.Write("Choose an option: ");

            // Eger user hec ne daxil etmese ve ya bosluq daxil etse,
            // input bos string olacaq ve proqram cokmeyecek.
            // Elave olaraq Trim() ile kenar bosluqlar silinir:
            string option = Console.ReadLine()?.Trim() ?? "";

            switch (option)
            {
                case "1":
                    ShowAllPosts();
                    break;
                case "2":
                    ViewPostById();
                    break;
                case "3":
                    LikePostById();
                    break;
                case "0":
                    return;
                default:
                    break;
            }
        }
    }
    private void ShowAllPosts()
    {
        Console.WriteLine("\n--- ALL POSTS ---");
        foreach (var post in FakeDataService.Posts)
        {
            Console.WriteLine($"ID: {post.Id} | Views: {post.ViewCount} | Likes: {post.LikeCount}");
            Console.WriteLine($"Content: {post.Content}");
            Console.WriteLine("----------------------------------");
        }
    }

    private void ViewPostById()
    {
        ShowPostIdsOnly();
        Console.Write("Enter the beginning of Post ID to view (first 6 characters): ");
        
        string input = Console.ReadLine()?.Trim() ?? "";

        var post = FakeDataService.Posts
            .FirstOrDefault(p => p.Id.ToString().StartsWith(input));

        if (post is null)
        {
            Console.WriteLine("No post found with the given ID prefix.");
            return;
        }

        if (!post.ViewHistory.Contains(_user.Email))
            post.ViewHistory.Add(_user.Email);
        post.AddView();

        NotificationService.SendNotification(_user, $"User viewed post with ID: {post.Id.ToString().Substring(0, 6)}");

        Console.WriteLine("\n--- Post Details ---");
        Console.WriteLine($"Content: {post.Content}");
        Console.WriteLine($"Views: {post.ViewCount} | Likes: {post.LikeCount}");

    }
    private void LikePostById()
    {
        ShowPostIdsOnly();
        Console.Write("Enter the beginning of Post ID to like (first 6 characters): ");
        
        string input = Console.ReadLine()?.Trim() ?? "";
        
        var post = FakeDataService.Posts
            .FirstOrDefault(p => p.Id.ToString().StartsWith(input));

        if(post is null)
        {
            Console.WriteLine("No post found with the given ID prefix.");
            return;
        }

        if (!post.LikeHistory.Contains(_user.Email))
            post.LikeHistory.Add(_user.Email);
        post.AddLike();  

        NotificationService.SendNotification(_user, $"User liked post with ID: {post.Id.ToString().Substring(0, 6)}");
        Console.WriteLine("Post liked successfully.");

    }

    private void ShowPostIdsOnly()
    {
        Console.WriteLine("--- Available Post IDs ---");
        foreach (var post in FakeDataService.Posts)
        {
            Console.WriteLine(post.Id.ToString().Substring(0,6));
        }
    }

}