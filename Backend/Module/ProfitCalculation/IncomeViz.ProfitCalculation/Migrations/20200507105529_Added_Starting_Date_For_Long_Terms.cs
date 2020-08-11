using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncomeViz.ProfitCalculation.Migrations
{
    public partial class Added_Starting_Date_For_Long_Terms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartingDate",
                schema: "profitcalculation",
                table: "LongTermIncomes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingDate",
                schema: "profitcalculation",
                table: "LongTermExpenses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartingDate",
                schema: "profitcalculation",
                table: "LongTermIncomes");

            migrationBuilder.DropColumn(
                name: "StartingDate",
                schema: "profitcalculation",
                table: "LongTermExpenses");
        }
    }
}
