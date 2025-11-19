namespace PayUni.Services;

public class AuthService : IAuthService
{
    public async Task<bool> SignInAsync(string email, string password)
    {
        await Task.Delay(500);
        return !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password);
    }

    public async Task<bool> SignUpAsync(string email, string password, string firstName, string lastName)
    {
        await Task.Delay(500);
        return !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password);
    }

    public async Task<bool> SignOutAsync()
    {
        await Task.Delay(300);
        return true;
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        await Task.Delay(100);
        return false;
    }
}
