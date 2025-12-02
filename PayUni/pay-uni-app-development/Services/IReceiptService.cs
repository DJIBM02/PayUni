using PayUni.Models;

namespace PayUni.Services;

public interface IReceiptService
{
    Task<Receipt> GenerateReceiptAsync(string transactionId, decimal amount, string paymentMethod);
    Task<string> DownloadReceiptAsync(Receipt receipt);
    Task<bool> ShareReceiptAsync(string filePath);
}
