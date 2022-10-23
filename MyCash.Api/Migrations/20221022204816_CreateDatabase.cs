using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCash.Api.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAcc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    initialBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    createdAt = table.Column<DateTime>(type: "SMALLDATETIME", maxLength: 60, nullable: false, defaultValueSql: "GETDATE()"),
                    updatedAt = table.Column<DateTime>(type: "SMALLDATETIME", maxLength: 60, nullable: false),
                    Observations = table.Column<string>(type: "NVARCHAR(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAcc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    MonthlyBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    BankAccID = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isIncome = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "SMALLDATETIME", maxLength: 60, nullable: false, defaultValueSql: "GETDATE()"),
                    updatedAt = table.Column<DateTime>(type: "SMALLDATETIME", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_BankAcc",
                        column: x => x.BankAccID,
                        principalTable: "BankAcc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Category",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "MonthlyBudget", "Name" },
                values: new object[] { 1, 1000m, "Casa" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "MonthlyBudget", "Name" },
                values: new object[] { 2, 700m, "Supermercado" });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Id",
                table: "Categories",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_Id",
                table: "Transactions",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BankAccID",
                table: "Transactions",
                column: "BankAccID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "BankAcc");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
