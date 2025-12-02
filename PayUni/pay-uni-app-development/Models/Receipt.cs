namespace PayUni.Models;

public class Receipt
{
    public string ReceiptNumber { get; set; } = string.Empty;
    public string TransactionId { get; set; } = string.Empty;
    public string StudentName { get; set; } = string.Empty;
    public string Matricule { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public DateTime TransactionDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public TransactionStatus Status { get; set; }
}
