using System.Text.RegularExpressions;
using NotifyApp.Utils;
namespace NotifyApp.Models;
public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public int Age { get; set; }

    private string _email = default!;
    public string Email
    {
        get => _email;
        set
        {
            if (!Validators.IsValidEmail(value))
            {
                throw new ArgumentException("Email must be in a valid format like name@example.com");
            }
            _email = value;
        }
    }

    private string _password = default!;
    public string Password
    {
        get => _password;
        set
        {
            if(!Validators.IsValidPassword(value))
            {
                throw new ArgumentException("Password must be at least 6 characters!");
            }
            _password = value;
        }
    }

    public override string ToString()
    {
        return $"{Name} {Surname} ({Email})";
    }

}
