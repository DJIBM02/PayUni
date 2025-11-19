using PayUni.Models;

namespace PayUni.Services;

public class FeeService : IFeeService
{
    public async Task<List<Fee>> GetFeesAsync()
    {
        await Task.Delay(300);
        return new List<Fee>
        {
            new Fee { Id = "1", Name = "Frais d'inscription", Description = "Inscription annuelle", Amount = 50.00m, DueDate = DateTime.Now.AddDays(30), Status = FeeStatus.Pending, Category = "Inscriptions" },
            new Fee { Id = "2", Name = "Cotisation", Description = "Cotisation mensuelle", Amount = 25.00m, DueDate = DateTime.Now, Status = FeeStatus.Overdue, Category = "Cotisations" },
            new Fee { Id = "3", Name = "Assurance", Description = "Assurance annuelle", Amount = 120.00m, DueDate = DateTime.Now.AddDays(60), Status = FeeStatus.Pending, Category = "Assurance" }
        };
    }

    public async Task<Fee?> GetFeeByIdAsync(string feeId)
    {
        await Task.Delay(200);
        var fees = await GetFeesAsync();
        return fees.FirstOrDefault(f => f.Id == feeId);
    }
}
