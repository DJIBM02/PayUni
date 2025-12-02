using PayUni.ViewModels;

namespace PayUni.Pages;

public partial class OnboardingPage : ContentPage
{
    public OnboardingPage()
    {
        InitializeComponent();
        BindingContext = new OnboardingViewModel();
    }
}
