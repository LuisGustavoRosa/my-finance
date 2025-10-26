using my_finance_domain.Enums;

namespace my_finance_domain.Entities;

public class Category
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public TypeCategory CategoryType { get; set; }
    
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}