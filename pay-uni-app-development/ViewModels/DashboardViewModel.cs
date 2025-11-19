using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PayUni.Models;
using PayUni.Services;

namespace PayUni.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
    private readonly IUserService _userService;
    private readonly ITransactionService _transactionService;

    [ObservableProperty]
    public User? currentUser;

    [ObservableProperty]
    public decimal balance = 0;

    [ObservableProperty]
    public ObservableCollection<Transaction> recentTransactions = [];

    [ObservableProperty]
    public bool isLoading = false;

    public DashboardViewModel()
    {
        _userService = new UserService();
        _transactionService = new TransactionService();
    }

    [RelayCommand]
    public async Task LoadDashboard()
    {
        IsLoading = true;

        try
        {
            CurrentUser = await _userService.GetCurrentUserAsync();
            if (CurrentUser != null)
            {
                Balance = CurrentUser.Balance;
                var transactions = await _transactionService.GetRecentTransactionsAsync(limit: 5);
                RecentTransactions = new ObservableCollection<Transaction>(transactions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error loading dashboard: {ex.Message}");
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    public async Task NavigateToPayment()
    {
        await Shell.Current.GoToAsync("payment");
    }

    [RelayCommand]
    public async Task NavigateToHistory()
    {
        await Shell.Current.GoToAsync("history");
    }
}
