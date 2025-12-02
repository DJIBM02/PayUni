using PayUni.Models;

namespace PayUni.Services;

public class FeeService : IFeeService
{
    public async Task<List<Fee>> GetFeesAsync()
    {
        await Task.Delay(300);
        return new List<Fee>
        {
            new Fee { Id = "1", Name = "Frais d'inscription", Description = "Inscription universitaire 2024-2025", Amount = 750000m, DueDate = new DateTime(2024, 12, 15), Status = FeeStatus.Pending, Category = "Inscriptions" },
            new Fee { Id = "2", Name = "Frais de scolarité", Description = "Premier semestre", Amount = 500000m, DueDate = DateTime.Now.AddDays(-5), Status = FeeStatus.Paid, Category = "Scolarité" },
            new Fee { Id = "3", Name = "Assurance étudiante", Description = "Assurance annuelle obligatoire", Amount = 25000m, DueDate = DateTime.Now.AddDays(45), Status = FeeStatus.Pending, Category = "Assurance" },
            new Fee { Id = "4", Name = "Frais de bibliothèque", Description = "Accès annuel bibliothèque", Amount = 15000m, DueDate = DateTime.Now.AddDays(-10), Status = FeeStatus.Paid, Category = "Services" },
            new Fee { Id = "5", Name = "Carte étudiante", Description = "Renouvellement carte", Amount = 5000m, DueDate = DateTime.Now.AddDays(20), Status = FeeStatus.Pending, Category = "Services" }
        };
    }

    public async Task<Fee?> GetFeeByIdAsync(string feeId)
    {
        await Task.Delay(200);
        var fees = await GetFeesAsync();
        return fees.FirstOrDefault(f => f.Id == feeId);
    }
}
