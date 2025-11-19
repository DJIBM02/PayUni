using PayUni.Models;

namespace PayUni.Services;

public class UserService : IUserService
{
    public async Task<User?> GetCurrentUserAsync()
    {
        await Task.Delay(300);
        return new User
        {
            Id = "1",
            Email = "user@example.com",
            FirstName = "Jean",
            LastName = "Dupont",
            Balance = 1250.50m,
            CreatedAt = DateTime.Now.AddMonths(-6)
        };
    }

    public async Task<User?> GetUserByIdAsync(string userId)
    {
        await Task.Delay(200);
        return await GetCurrentUserAsync();
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        await Task.Delay(500);
        return true;
    }

    public async Task<bool> SignOutAsync()
    {
        await Task.Delay(300);
        return true;
    }
}
