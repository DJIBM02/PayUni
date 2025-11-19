using PayUni.Models;

namespace PayUni.Services;

public interface ITransactionService
{
    Task<List<Transaction>> GetAllTransactionsAsync();
    Task<List<Transaction>> GetRecentTransactionsAsync(int limit = 10);
    Task<Transaction?> GetTransactionByIdAsync(string transactionId);
    Task<bool> CreateTransactionAsync(Transaction transaction);
}
