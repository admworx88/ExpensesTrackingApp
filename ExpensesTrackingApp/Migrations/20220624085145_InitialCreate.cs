using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpensesTrackingApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(19,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(25)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Customer A" },
                    { 2, "Customer B" },
                    { 3, "Customer C" },
                    { 4, "Customer D" },
                    { 5, "Customer E" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CustomerId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Project One" },
                    { 2, 1, "Project One" },
                    { 3, 2, "Project Two" },
                    { 4, 2, "Project Three" },
                    { 5, 3, "Project Four" },
                    { 6, 4, "Project Three" },
                    { 7, 4, "Project Four" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
