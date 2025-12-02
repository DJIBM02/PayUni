using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PayUni.ViewModels;

public partial class OnboardingViewModel : ObservableObject
{
    [RelayCommand]
    public async Task GetStarted()
    {
        await Shell.Current.GoToAsync("//login");
    }
}
