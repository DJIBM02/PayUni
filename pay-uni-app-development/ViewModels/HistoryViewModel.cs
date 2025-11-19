using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PayUni.Models;
using PayUni.Services;

namespace PayUni.ViewModels;

public partial class HistoryViewModel : ObservableObject
{
    private readonly ITransactionService _transactionService;

    [ObservableProperty]
    public ObservableCollection<Transaction> transactions = [];

    [ObservableProperty]
    public bool isLoading = false;

    public HistoryViewModel()
    {
        _transactionService = new TransactionService();
    }

    [RelayCommand]
    public async Task LoadHistory()
    {
        IsLoading = true;

        try
        {
            var transactions = await _transactionService.GetAllTransactionsAsync();
            Transactions = new ObservableCollection<Transaction>(transactions.OrderByDescending(t => t.CreatedAt));
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error loading history: {ex.Message}");
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    public async Task ViewReceipt(Transaction transaction)
    {
        if (string.IsNullOrEmpty(transaction.ReceiptUrl))
            return;

        await Launcher.Default.OpenAsync(transaction.ReceiptUrl);
    }
}
