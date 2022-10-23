using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCash.Api.Entities;

namespace MyCash.Api.Data.Mappings
{
    public class BankAccMap : IEntityTypeConfiguration<BankAcc>
    {
        public void Configure(EntityTypeBuilder<BankAcc> builder)
        {
            //Table
            builder.ToTable("BankAcc");

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

            builder.Property(x => x.initialBalance)
               .IsRequired()
               .HasColumnName("initialBalance")
               .HasDefaultValue(0);

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

            builder.Property(x => x.Observation)
                   .HasColumnName("Observations")
                   .HasColumnType("NVARCHAR")
                   .HasMaxLength(4000);




        }
    }
}
