namespace PayUni.Services;

public interface IAuthService
{
    Task<bool> SignInAsync(string email, string password);
    Task<bool> SignUpAsync(string email, string password, string firstName, string lastName);
    Task<bool> SignOutAsync();
    Task<bool> IsAuthenticatedAsync();
}
