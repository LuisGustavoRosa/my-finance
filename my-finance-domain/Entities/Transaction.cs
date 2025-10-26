using my_finance_domain.Enums;

namespace my_finance_domain.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
    public decimal Value { get; set; }
    public TypeCategory TransactionType { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public string ? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    
    
    public Account Account { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public User User { get; set; } = null!;
}