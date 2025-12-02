using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PayUni.Services;

namespace PayUni.ViewModels;

public partial class RegisterViewModel : ObservableObject
{
    private readonly IAuthService _authService;

    [ObservableProperty]
    public string fullName = string.Empty;

    [ObservableProperty]
    public string matricule = string.Empty;

    [ObservableProperty]
    public string email = string.Empty;

    [ObservableProperty]
    public string password = string.Empty;

    [ObservableProperty]
    public string confirmPassword = string.Empty;

    [ObservableProperty]
    public bool isPasswordVisible = false;

    [ObservableProperty]
    public bool isConfirmPasswordVisible = false;

    [ObservableProperty]
    public bool isLoading = false;

    [ObservableProperty]
    public string errorMessage = string.Empty;

    public RegisterViewModel()
    {
        _authService = new AuthService();
    }

    [RelayCommand]
    public void TogglePasswordVisibility()
    {
        IsPasswordVisible = !IsPasswordVisible;
    }

    [RelayCommand]
    public void ToggleConfirmPasswordVisibility()
    {
        IsConfirmPasswordVisible = !IsConfirmPasswordVisible;
    }

    [RelayCommand]
    public async Task SignUp()
    {
        if (string.IsNullOrWhiteSpace(FullName) ||
            string.IsNullOrWhiteSpace(Matricule) ||
            string.IsNullOrWhiteSpace(Email) ||
            string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Veuillez remplir tous les champs";
            return;
        }

        if (Password != ConfirmPassword)
        {
            ErrorMessage = "Les mots de passe ne correspondent pas";
            return;
        }

        if (Password.Length < 6)
        {
            ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères";
            return;
        }

        IsLoading = true;
        ErrorMessage = string.Empty;

        try
        {
            var names = FullName.Split(' ', 2);
            var firstName = names.Length > 0 ? names[0] : string.Empty;
            var lastName = names.Length > 1 ? names[1] : string.Empty;

            var success = await _authService.SignUpAsync(Email, Password, firstName, lastName);
            if (success)
            {
                await Shell.Current.GoToAsync("//login");
            }
            else
            {
                ErrorMessage = "Erreur lors de l'inscription";
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
    public async Task NavigateToLogin()
    {
        await Shell.Current.GoToAsync("//login");
    }

    [RelayCommand]
    public void NavigateToRegister()
    {
        // Already on register page
    }
}
