namespace PayUni.Pages;

using PayUni.ViewModels;

public partial class PaymentPage : ContentPage
{
    public PaymentPage()
    {
        InitializeComponent();
        BindingContext = new PaymentViewModel();
    }
}

public static class PaymentMethods
{
    public static List<string> Methods => new() { "Carte bancaire", "Virement", "Prélèvement automatique" };
}
