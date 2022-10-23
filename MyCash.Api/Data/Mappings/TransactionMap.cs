using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCash.Api.Entities;

namespace MyCash.Api.Data.Mappings;

public class TransactionMap : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        //Table
        builder.ToTable("Transactions");

        //Primary Key
        builder.HasKey(x => x.Id);

        //Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        //Properties
        builder.Property(x => x.Name)
               .IsRequired()
               .HasColumnName("Name")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(80);

        builder.Property(x => x.Amount)
               .IsRequired()
               .HasColumnName("Amount")
               .HasDefaultValue(0);

        builder.Property(x => x.Date)
               .HasColumnName("Date")
               .IsRequired();

        builder.Property(x => x.isIncome)
               .HasColumnName("isIncome")
               .IsRequired();

        builder.Property(x => x.createdAt)
                .IsRequired()
                .HasColumnName("createdAt")
                .HasColumnType("SMALLDATETIME")
                .HasMaxLength(60)
                .HasDefaultValueSql("GETDATE()");

        builder.Property(x => x.updatedAt)
                .HasColumnName("updatedAt")
                .HasColumnType("SMALLDATETIME")
                .HasMaxLength(60);

        //Index
        builder.HasIndex(x => x.Id, "IX_Transaction_Id")
               .IsUnique();

        //Relationships
        builder
                .HasOne(x => x.BankAcc)
                .WithMany(x => x.Transactions)
                .HasConstraintName("FK_Transaction_BankAcc")
                .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Transactions)
            .HasConstraintName("FK_Transaction_Category")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
