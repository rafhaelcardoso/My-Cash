﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCash.Api.ApiContext;

#nullable disable

namespace MyCash.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyCash.Api.Entities.BankAcc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("Name");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasMaxLength(8000)
                        .HasColumnType("NVARCHAR(8000)")
                        .HasColumnName("Observations");

                    b.Property<DateTime>("createdAt")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<decimal>("initialBalance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m)
                        .HasColumnName("initialBalance");

                    b.Property<DateTime>("updatedAt")
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("updatedAt");

                    b.HasKey("Id");

                    b.ToTable("BankAcc", (string)null);
                });

            modelBuilder.Entity("MyCash.Api.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("MonthlyBudget")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_Category_Id")
                        .IsUnique();

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MonthlyBudget = 1000m,
                            Name = "Casa"
                        },
                        new
                        {
                            Id = 2,
                            MonthlyBudget = 700m,
                            Name = "Supermercado"
                        });
                });

            modelBuilder.Entity("MyCash.Api.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m)
                        .HasColumnName("Amount");

                    b.Property<int>("BankAccID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR(80)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("createdAt")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("isIncome")
                        .HasColumnType("bit")
                        .HasColumnName("isIncome");

                    b.Property<DateTime>("updatedAt")
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("updatedAt");

                    b.HasKey("Id");

                    b.HasIndex("BankAccID");

                    b.HasIndex("CategoryId");

                    b.HasIndex(new[] { "Id" }, "IX_Transaction_Id")
                        .IsUnique();

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("MyCash.Api.Entities.Transaction", b =>
                {
                    b.HasOne("MyCash.Api.Entities.BankAcc", "BankAcc")
                        .WithMany("Transactions")
                        .HasForeignKey("BankAccID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Transaction_BankAcc");

                    b.HasOne("MyCash.Api.Entities.Category", "Category")
                        .WithMany("Transactions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Transaction_Category");

                    b.Navigation("BankAcc");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MyCash.Api.Entities.BankAcc", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("MyCash.Api.Entities.Category", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}