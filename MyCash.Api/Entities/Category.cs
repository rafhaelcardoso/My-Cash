namespace MyCash.Api.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;    
    public decimal MonthlyBudget { get; set; }
    public List<Transaction> Transactions { get; set; }
}
