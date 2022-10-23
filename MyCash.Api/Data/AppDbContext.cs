using Microsoft.EntityFrameworkCore;
using MyCash.Api.Data.Mappings;
using MyCash.Api.Entities;

namespace MyCash.Api.Data;

public class AppDbContext : DbContext
{

    public DbSet<BankAcc> BankAcc { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost,1433;Database=MyCash;User ID=sa;Password=Test@ndo2022");

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new BankAccMap());
        builder.ApplyConfiguration(new CategoryMap());
        builder.ApplyConfiguration(new TransactionMap());

        //Categories
        builder.Entity<Category>().HasData(new Category
        {
            Id = 1,
            Name = "Casa",
            MonthlyBudget = 1000
        });
        builder.Entity<Category>().HasData(new Category
        {
            Id = 2,
            Name = "Supermercado",
            MonthlyBudget = 700
        });
    }
}

