using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson06.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFinance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IncomeStatus",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalLimit",
                table: "Transactions",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncomeStatus",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TotalLimit",
                table: "Transactions");
        }
    }
}
