using NotifyApp.Models;

namespace NotifyApp.Services;
public interface IAuthenticationService
{
    User AuthenticateUser(string email, string password);
    Admin AuthenticateAdmin(string usernameOrEmail, string password);

}