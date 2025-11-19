namespace PayUni.Pages;

using PayUni.ViewModels;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }
}
