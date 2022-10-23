using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCash.Api.Entities;

namespace MyCash.Api.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Table
            builder.ToTable("Categories");

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

            builder.Property(x => x.MonthlyBudget)
                   .HasDefaultValue(0);

            //Index
            builder.HasIndex(x => x.Id, "IX_Category_Id")
                   .IsUnique();
        }
    }
}
