using NotifyApp.Menus;
using NotifyApp.Models;
using NotifyApp.Services;
using System;

namespace NotifyApp.Core;
public class SystemManager
{
    private readonly IAuthenticationService _authService;

    public SystemManager(IAuthenticationService authService)
    {
        _authService = authService;
    }

    public void Run()
    {
        FakeDataService.Seed();
        Console.WriteLine("Welcome to NotifyApp!");

        while (true)
        {
            Console.Write("Login as (A)dmin or (U)ser or (E)xit: ");
            // role null ola biler, ona gore de null-conditional operatoru(?)
            // istifade edirik, role null olsa, expression nul qaytarir ve
            // muqayise false olur.
            string? role = Console.ReadLine()?.Trim().ToUpper();

            if (role == "E")
            {
                Console.WriteLine("Exiting NotifyApp. Goodbye!");
                break;
            }

            if (role != "A" && role != "U")
            {
                Console.WriteLine("Invalid selection. Please choose A, U or E.");
                continue;
            }

            Console.Write("Enter email or username: ");
            string? login = Console.ReadLine();

            Console.Write("Enter password: ");
            string? password = Console.ReadLine();

            try
            {
                if (role == "A")
                {
                    // Burada ise null-forgiving operatoru(!) istifade edirik.
                    // Cunki biz artiq userden input almisiq ve
                    // AuthenticateAdmin icinde null-check var.
                    // Yeni login/password null olmayacaq! — input yoxlanılıb.
                    Admin admin = _authService.AuthenticateAdmin(login!, password!);
                    AdminMenu menu = new AdminMenu(admin);
                    menu.Run();

                }
                else if (role == "U")
                {
                    User user = _authService.AuthenticateUser(login!, password!);
                    UserMenu menu = new UserMenu(user);
                    menu.Run();

                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access Denied: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Invalid input: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            Console.WriteLine();
        }
    }
}