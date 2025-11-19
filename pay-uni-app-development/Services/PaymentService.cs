using PayUni.Models;

namespace PayUni.Services;

public class PaymentService : IPaymentService
{
    public async Task<bool> ProcessPaymentAsync(Transaction transaction)
    {
        await Task.Delay(2000);
        return true;
    }

    public async Task<bool> VerifyPaymentAsync(string transactionId)
    {
        await Task.Delay(300);
        return true;
    }
}
