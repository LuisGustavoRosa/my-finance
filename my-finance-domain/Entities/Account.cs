using my_finance_domain.Enums;

namespace my_finance_domain.Entities;

public class Account
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public TypeAccount AccountType { get; set; }
    public decimal InitialBalance { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}