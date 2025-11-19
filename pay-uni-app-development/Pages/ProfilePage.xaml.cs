namespace PayUni.Pages;

using PayUni.ViewModels;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
        BindingContext = new ProfileViewModel();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var vm = (ProfileViewModel)BindingContext;
        await vm.LoadProfileCommand.ExecuteAsync(null);
    }
}
