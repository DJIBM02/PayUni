using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PayUni.Models;
using PayUni.Services;

namespace PayUni.ViewModels;

public partial class PaymentViewModel : ObservableObject
{
    private readonly IPaymentService _paymentService;

    [ObservableProperty]
    public decimal amount = 0;

    [ObservableProperty]
    public string description = string.Empty;

    [ObservableProperty]
    public string paymentMethod = "MTN";

    [ObservableProperty]
    public string phoneNumber = string.Empty;

    [ObservableProperty]
    public bool isLoading = false;

    [ObservableProperty]
    public bool isProcessing = false;

    [ObservableProperty]
    public string statusMessage = string.Empty;

    public PaymentViewModel()
    {
        _paymentService = new PaymentService();
        Amount = 750000; // Default amount from Figma
    }

    [RelayCommand]
    public void SelectPaymentMethod(string method)
    {
        PaymentMethod = method;
    }

    [RelayCommand]
    public async Task ProcessPayment()
    {
        if (Amount <= 0)
        {
            StatusMessage = "Veuillez entrer un montant valide";
            return;
        }

        if (string.IsNullOrWhiteSpace(PhoneNumber))
        {
            StatusMessage = "Veuillez entrer un numéro de téléphone";
            return;
        }

        IsProcessing = true;
        StatusMessage = "Traitement du paiement...";

        try
        {
            var transaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Amount = Amount,
                Description = $"Paiement via {PaymentMethod}",
                Status = TransactionStatus.Pending,
                CreatedAt = DateTime.Now
            };

            var success = await _paymentService.ProcessPaymentAsync(transaction);

            if (success)
            {
                StatusMessage = "Paiement réussi!";
                await Task.Delay(1000);
                await Shell.Current.GoToAsync("//paymentconfirmation", new Dictionary<string, object>
                {
                    { "TransactionId", transaction.Id },
                    { "Amount", Amount },
                    { "PaymentMethod", PaymentMethod }
                });
            }
            else
            {
                StatusMessage = "Erreur lors du traitement du paiement";
            }
        }
        catch (Exception ex)
        {
            StatusMessage = $"Erreur: {ex.Message}";
        }
        finally
        {
            IsProcessing = false;
        }
    }

    [RelayCommand]
    public async Task Cancel()
    {
        await Shell.Current.GoToAsync("..");
    }
}
