using PayUni.ViewModels;

namespace PayUni.Pages;

public partial class PaymentConfirmationPage : ContentPage
{
    public PaymentConfirmationPage()
    {
        InitializeComponent();
        BindingContext = new PaymentConfirmationViewModel();
    }
}
