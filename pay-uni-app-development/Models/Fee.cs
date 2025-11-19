namespace PayUni.Models;

public class Fee
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
    public FeeStatus Status { get; set; }
    public string Category { get; set; } = string.Empty;
}

public enum FeeStatus
{
    Pending,
    PartiallyPaid,
    Paid,
    Overdue
}
