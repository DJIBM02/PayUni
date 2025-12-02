using PayUni.ViewModels;

namespace PayUni.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
        BindingContext = new RegisterViewModel();
    }
}
