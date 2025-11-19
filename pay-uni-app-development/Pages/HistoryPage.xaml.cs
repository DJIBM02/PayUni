namespace PayUni.Pages;

using PayUni.ViewModels;

public partial class HistoryPage : ContentPage
{
    public HistoryPage()
    {
        InitializeComponent();
        BindingContext = new HistoryViewModel();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (HistoryViewModel)BindingContext;
        await vm.LoadHistoryCommand.ExecuteAsync(null);
    }
}
