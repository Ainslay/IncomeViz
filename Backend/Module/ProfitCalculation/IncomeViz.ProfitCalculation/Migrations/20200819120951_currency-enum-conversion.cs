using Microsoft.EntityFrameworkCore.Migrations;

namespace IncomeViz.ProfitCalculation.Migrations
{
    public partial class currencyenumconversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                schema: "profitcalculation",
                table: "Predictions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Currency",
                schema: "profitcalculation",
                table: "Predictions",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
