namespace PayUni.Pages;

using PayUni.ViewModels;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();
        BindingContext = new DashboardViewModel();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (DashboardViewModel)BindingContext;
        await vm.LoadDashboardCommand.ExecuteAsync(null);
    }
}
