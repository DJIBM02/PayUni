using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PayUni.Models;
using PayUni.Services;

namespace PayUni.ViewModels;

public partial class ProfileViewModel : ObservableObject
{
    private readonly IUserService _userService;

    [ObservableProperty]
    public User? currentUser;

    [ObservableProperty]
    public bool isEditing = false;

    [ObservableProperty]
    public bool isLoading = false;

    public ProfileViewModel()
    {
        _userService = new UserService();
    }

    [RelayCommand]
    public async Task LoadProfile()
    {
        IsLoading = true;

        try
        {
            CurrentUser = await _userService.GetCurrentUserAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error loading profile: {ex.Message}");
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    public void ToggleEditing()
    {
        IsEditing = !IsEditing;
    }

    [RelayCommand]
    public async Task SaveProfile()
    {
        if (CurrentUser == null)
            return;

        IsLoading = true;

        try
        {
            await _userService.UpdateUserAsync(CurrentUser);
            IsEditing = false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error saving profile: {ex.Message}");
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    public async Task SignOut()
    {
        await _userService.SignOutAsync();
        await Shell.Current.GoToAsync("login");
    }
}
