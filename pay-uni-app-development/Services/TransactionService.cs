using PayUni.Models;

namespace PayUni.Services;

public class TransactionService : ITransactionService
{
    public async Task<List<Transaction>> GetAllTransactionsAsync()
    {
        await Task.Delay(300);
        return new List<Transaction>
        {
            new Transaction { Id = "1", Amount = 150.00m, Description = "Frais inscription", Status = TransactionStatus.Completed, CreatedAt = DateTime.Now.AddDays(-5) },
            new Transaction { Id = "2", Amount = 75.50m, Description = "Cotisation annuelle", Status = TransactionStatus.Completed, CreatedAt = DateTime.Now.AddDays(-10) },
            new Transaction { Id = "3", Amount = 200.00m, Description = "Adhésion", Status = TransactionStatus.Completed, CreatedAt = DateTime.Now.AddDays(-15) }
        };
    }

    public async Task<List<Transaction>> GetRecentTransactionsAsync(int limit = 10)
    {
        var transactions = await GetAllTransactionsAsync();
        return transactions.Take(limit).ToList();
    }

    public async Task<Transaction?> GetTransactionByIdAsync(string transactionId)
    {
        await Task.Delay(200);
        var transactions = await GetAllTransactionsAsync();
        return transactions.FirstOrDefault(t => t.Id == transactionId);
    }

    public async Task<bool> CreateTransactionAsync(Transaction transaction)
    {
        await Task.Delay(500);
        return true;
    }
}
