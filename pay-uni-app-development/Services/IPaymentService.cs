using PayUni.Models;

namespace PayUni.Services;

public interface IPaymentService
{
    Task<bool> ProcessPaymentAsync(Transaction transaction);
    Task<bool> VerifyPaymentAsync(string transactionId);
}
