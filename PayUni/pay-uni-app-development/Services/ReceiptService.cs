using System.Text;
using PayUni.Models;

namespace PayUni.Services;

public class ReceiptService : IReceiptService
{
    private readonly IUserService _userService;

    public ReceiptService()
    {
        _userService = new UserService();
    }

    public async Task<Receipt> GenerateReceiptAsync(string transactionId, decimal amount, string paymentMethod)
    {
        await Task.Delay(200);

        var user = await _userService.GetCurrentUserAsync();

        return new Receipt
        {
            ReceiptNumber = $"QUITUS-{DateTime.Now:yyyyMMdd}-{transactionId.Substring(0, 8).ToUpper()}",
            TransactionId = transactionId,
            StudentName = $"{user?.FirstName} {user?.LastName}",
            Matricule = user?.Matricule ?? "N/A",
            Amount = amount,
            PaymentMethod = paymentMethod,
            TransactionDate = DateTime.Now,
            Description = $"Paiement via {paymentMethod}",
            Status = TransactionStatus.Completed
        };
    }

    public async Task<string> DownloadReceiptAsync(Receipt receipt)
    {
        await Task.Delay(500);

        // Generate receipt content (text format for now)
        var receiptContent = GenerateReceiptContent(receipt);

        // In a real app, you would:
        // 1. Generate a PDF using a library like QuestPDF or iText
        // 2. Save to device storage using MAUI File System
        // 3. Return the file path

        // For mock implementation, we'll simulate the download
        var fileName = $"Quitus_{receipt.ReceiptNumber}.txt";
        var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var filePath = Path.Combine(documentsPath, "PayUni", fileName);

        try
        {
            // Create directory if it doesn't exist
            var directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Write receipt content to file
            await File.WriteAllTextAsync(filePath, receiptContent);

            return filePath;
        }
        catch (Exception)
        {
            // Return a mock path if file creation fails
            return $"Mock path: {filePath}";
        }
    }

    public async Task<bool> ShareReceiptAsync(string filePath)
    {
        await Task.Delay(300);

        // In a real app, you would use:
        // await Share.RequestAsync(new ShareFileRequest
        // {
        //     Title = "Partager le quitus",
        //     File = new ShareFile(filePath)
        // });

        return true;
    }

    private string GenerateReceiptContent(Receipt receipt)
    {
        var content = new StringBuilder();
        content.AppendLine("═══════════════════════════════════════════");
        content.AppendLine("            QUITUS DE PAIEMENT             ");
        content.AppendLine("           PAYUNI - Université             ");
        content.AppendLine("═══════════════════════════════════════════");
        content.AppendLine();
        content.AppendLine($"N° de Quitus    : {receipt.ReceiptNumber}");
        content.AppendLine($"N° Transaction  : {receipt.TransactionId}");
        content.AppendLine();
        content.AppendLine("───────────────────────────────────────────");
        content.AppendLine("          INFORMATIONS ÉTUDIANT            ");
        content.AppendLine("───────────────────────────────────────────");
        content.AppendLine($"Nom complet     : {receipt.StudentName}");
        content.AppendLine($"Matricule       : {receipt.Matricule}");
        content.AppendLine();
        content.AppendLine("───────────────────────────────────────────");
        content.AppendLine("         DÉTAILS DU PAIEMENT               ");
        content.AppendLine("───────────────────────────────────────────");
        content.AppendLine($"Montant payé    : {receipt.Amount:N0} FCFA");
        content.AppendLine($"Méthode         : {receipt.PaymentMethod}");
        content.AppendLine($"Description     : {receipt.Description}");
        content.AppendLine($"Date            : {receipt.TransactionDate:dd/MM/yyyy HH:mm}");
        content.AppendLine($"Statut          : {GetStatusText(receipt.Status)}");
        content.AppendLine();
        content.AppendLine("═══════════════════════════════════════════");
        content.AppendLine("   Ce document atteste du paiement des     ");
        content.AppendLine("      frais universitaires mentionnés.     ");
        content.AppendLine();
        content.AppendLine("        Généré par PayUni Mobile App       ");
        content.AppendLine($"           {DateTime.Now:dd/MM/yyyy HH:mm}          ");
        content.AppendLine("═══════════════════════════════════════════");

        return content.ToString();
    }

    private string GetStatusText(TransactionStatus status)
    {
        return status switch
        {
            TransactionStatus.Completed => "✓ PAYÉ",
            TransactionStatus.Pending => "EN ATTENTE",
            TransactionStatus.Failed => "ÉCHOUÉ",
            TransactionStatus.Cancelled => "ANNULÉ",
            _ => "INCONNU"
        };
    }
}
