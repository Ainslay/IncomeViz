using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncomeViz.ProfitCalculation.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                "profitcalculation");

            migrationBuilder.CreateTable(
                "Predictions",
                schema: "profitcalculation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>("decimal(18, 2)", nullable: true),
                    Currency = table.Column<int>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Predictions", x => x.Id); });

            migrationBuilder.CreateTable(
                "LongTermExpenses",
                schema: "profitcalculation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<Guid>(nullable: false),
                    PredictionId = table.Column<int>(nullable: false),
                    EffectiveDate = table.Column<DateTime>(nullable: true),
                    ExecutionDay = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>("decimal(18, 2)", nullable: true),
                    Currency = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LongTermExpenses", x => x.Id);
                    table.ForeignKey(
                        "FK_LongTermExpenses_Predictions_PredictionId",
                        x => x.PredictionId,
                        principalSchema: "profitcalculation",
                        principalTable: "Predictions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "LongTermIncomes",
                schema: "profitcalculation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<Guid>(nullable: false),
                    PredictionId = table.Column<int>(nullable: false),
                    EffectiveDate = table.Column<DateTime>(nullable: true),
                    ExecutionDay = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>("decimal(18, 2)", nullable: true),
                    Currency = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LongTermIncomes", x => x.Id);
                    table.ForeignKey(
                        "FK_LongTermIncomes_Predictions_PredictionId",
                        x => x.PredictionId,
                        principalSchema: "profitcalculation",
                        principalTable: "Predictions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ShortTermExpenses",
                schema: "profitcalculation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<Guid>(nullable: false),
                    PredictionId = table.Column<int>(nullable: false),
                    ExecutionDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>("decimal(18, 2)", nullable: true),
                    Currency = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortTermExpenses", x => x.Id);
                    table.ForeignKey(
                        "FK_ShortTermExpenses_Predictions_PredictionId",
                        x => x.PredictionId,
                        principalSchema: "profitcalculation",
                        principalTable: "Predictions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ShortTermIncomes",
                schema: "profitcalculation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<Guid>(nullable: false),
                    PredictionId = table.Column<int>(nullable: false),
                    ExecutionDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>("decimal(18, 2)", nullable: true),
                    Currency = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortTermIncomes", x => x.Id);
                    table.ForeignKey(
                        "FK_ShortTermIncomes_Predictions_PredictionId",
                        x => x.PredictionId,
                        principalSchema: "profitcalculation",
                        principalTable: "Predictions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_LongTermExpenses_PredictionId",
                schema: "profitcalculation",
                table: "LongTermExpenses",
                column: "PredictionId");

            migrationBuilder.CreateIndex(
                "IX_LongTermIncomes_PredictionId",
                schema: "profitcalculation",
                table: "LongTermIncomes",
                column: "PredictionId");

            migrationBuilder.CreateIndex(
                "IX_ShortTermExpenses_PredictionId",
                schema: "profitcalculation",
                table: "ShortTermExpenses",
                column: "PredictionId");

            migrationBuilder.CreateIndex(
                "IX_ShortTermIncomes_PredictionId",
                schema: "profitcalculation",
                table: "ShortTermIncomes",
                column: "PredictionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "LongTermExpenses",
                "profitcalculation");

            migrationBuilder.DropTable(
                "LongTermIncomes",
                "profitcalculation");

            migrationBuilder.DropTable(
                "ShortTermExpenses",
                "profitcalculation");

            migrationBuilder.DropTable(
                "ShortTermIncomes",
                "profitcalculation");

            migrationBuilder.DropTable(
                "Predictions",
                "profitcalculation");
        }
    }
}