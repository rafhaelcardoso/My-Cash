namespace MyCash.Api.Entities;

public class Transaction
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public decimal Amount { get; set; }
    public int BankAccID { get; set; }
    public BankAcc? BankAcc { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public DateTime Date { get; set; }
    public bool isIncome { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }


}
