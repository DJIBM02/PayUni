using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PayUni.Services;

namespace PayUni.ViewModels;

[QueryProperty(nameof(TransactionId), "TransactionId")]
[QueryProperty(nameof(Amount), "Amount")]
[QueryProperty(nameof(PaymentMethod), "PaymentMethod")]
public partial class PaymentConfirmationViewModel : ObservableObject
{
    private readonly IReceiptService _receiptService;

    [ObservableProperty]
    public string transactionId = string.Empty;

    [ObservableProperty]
    public decimal amount = 0;

    [ObservableProperty]
    public string paymentMethod = string.Empty;

    [ObservableProperty]
    public DateTime transactionDate = DateTime.Now;

    [ObservableProperty]
    public bool isDownloading = false;

    [ObservableProperty]
    public string downloadMessage = string.Empty;

    public PaymentConfirmationViewModel()
    {
        _receiptService = new ReceiptService();
    }

    [RelayCommand]
    public async Task ViewHistory()
    {
        await Shell.Current.GoToAsync("//history");
    }

    [RelayCommand]
    public async Task DownloadReceipt()
    {
        if (IsDownloading) return;

        IsDownloading = true;
        DownloadMessage = "Génération du quitus...";

        try
        {
            // Generate receipt
            var receipt = await _receiptService.GenerateReceiptAsync(
                TransactionId,
                Amount,
                PaymentMethod
            );

            DownloadMessage = "Téléchargement en cours...";

            // Download receipt
            var filePath = await _receiptService.DownloadReceiptAsync(receipt);

            DownloadMessage = $"Quitus téléchargé avec succès!\n{receipt.ReceiptNumber}";

            // Optionally share the receipt
            await Task.Delay(1500);
            DownloadMessage = string.Empty;

            // Show success message
            await Application.Current.MainPage.DisplayAlert(
                "Quitus téléchargé",
                $"Le quitus de paiement a été téléchargé avec succès.\n\nN° de quitus: {receipt.ReceiptNumber}\n\nVous pouvez le retrouver dans vos documents.",
                "OK"
            );
        }
        catch (Exception ex)
        {
            DownloadMessage = "Erreur lors du téléchargement";
            await Application.Current.MainPage.DisplayAlert(
                "Erreur",
                $"Impossible de télécharger le quitus: {ex.Message}",
                "OK"
            );
        }
        finally
        {
            IsDownloading = false;
            await Task.Delay(2000);
            DownloadMessage = string.Empty;
        }
    }
}
