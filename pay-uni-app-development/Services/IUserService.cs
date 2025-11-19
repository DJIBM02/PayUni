using PayUni.Models;

namespace PayUni.Services;

public interface IUserService
{
    Task<User?> GetCurrentUserAsync();
    Task<User?> GetUserByIdAsync(string userId);
    Task<bool> UpdateUserAsync(User user);
    Task<bool> SignOutAsync();
}
