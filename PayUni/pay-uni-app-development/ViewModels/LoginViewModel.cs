using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PayUni.Services;

namespace PayUni.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly IAuthService _authService;

    [ObservableProperty]
    public string email = string.Empty;

    [ObservableProperty]
    public string password = string.Empty;

    [ObservableProperty]
    public bool isLoading = false;

    [ObservableProperty]
    public string errorMessage = string.Empty;

    [ObservableProperty]
    public bool isPasswordVisible = false;

    public LoginViewModel()
    {
        _authService = new AuthService();
    }

    [RelayCommand]
    public void TogglePasswordVisibility()
    {
        IsPasswordVisible = !IsPasswordVisible;
    }

    [RelayCommand]
    public async Task ForgotPassword()
    {
        // TODO: Implement forgot password functionality
        await Task.CompletedTask;
    }

    [RelayCommand]
    public async Task NavigateToRegister()
    {
        await Shell.Current.GoToAsync("//signup");
    }

    [RelayCommand]
    public void NavigateToLogin()
    {
        // Already on login page
    }

    [RelayCommand]
    public async Task SignIn()
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Veuillez remplir tous les champs";
            return;
        }

        IsLoading = true;
        ErrorMessage = string.Empty;

        try
        {
            var success = await _authService.SignInAsync(Email, Password);
            if (success)
            {
                await Shell.Current.GoToAsync("//dashboard");
            }
            else
            {
                ErrorMessage = "Email ou mot de passe incorrect";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    public async Task SignUp()
    {
        await Shell.Current.GoToAsync("//signup");
    }
}
