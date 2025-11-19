namespace PayUni.Models;

public class Transaction
{
    public string Id { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public TransactionStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? ReceiptUrl { get; set; }
}

public enum TransactionStatus
{
    Pending,
    Completed,
    Failed,
    Cancelled
}
