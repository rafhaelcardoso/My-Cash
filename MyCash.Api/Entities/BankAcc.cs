namespace MyCash.Api.Entities;

public class BankAcc
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public decimal initialBalance { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public string Observation { get; set; } = String.Empty;
    public ICollection<Transaction> Transactions { get; set; }
        = new List<Transaction>();
}
