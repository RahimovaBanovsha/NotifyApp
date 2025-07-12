using NotifyApp.Models;

namespace NotifyApp.Services;
public class AuthenticationService:IAuthenticationService
{
    public User AuthenticateUser(string email,string password)
    {

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Email and password cannot be empty.");
        }

        // Email-check--> Case-Insensitive
        // Password-check--> Case-Sensitive
        var user = FakeDataService.Users.FirstOrDefault(u =>
            u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
            u.Password == password);

        if (user is null)
        {
            throw new UnauthorizedAccessException("Username/email or password is incorrect.");
        }

        return user;
    }

    public Admin AuthenticateAdmin(string usernameOrEmail, string password)
    {

        if (string.IsNullOrWhiteSpace(usernameOrEmail) || string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Username/email and password cannot be empty.");
        }

        var admin = Admin.Instance;

        if (
            !(admin.Email.Equals(usernameOrEmail, StringComparison.OrdinalIgnoreCase) ||
              admin.Username.Equals(usernameOrEmail, StringComparison.OrdinalIgnoreCase)) ||
              admin.Password != password)
        {
            throw new UnauthorizedAccessException("Username/email or password is incorrect.");
        }
        return admin;
    }
}