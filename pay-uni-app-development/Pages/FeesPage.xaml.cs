namespace PayUni.Pages;

using PayUni.ViewModels;

public partial class FeesPage : ContentPage
{
    public FeesPage()
    {
        InitializeComponent();
        BindingContext = new FeesViewModel();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (FeesViewModel)BindingContext;
        await vm.LoadFeesCommand.ExecuteAsync(null);
    }
}
