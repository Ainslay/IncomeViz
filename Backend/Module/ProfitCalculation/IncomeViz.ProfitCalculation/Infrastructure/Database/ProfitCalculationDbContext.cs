using Microsoft.EntityFrameworkCore;
using IncomeViz.ProfitCalculation.Domain.Expense.LongTerm;
using IncomeViz.ProfitCalculation.Domain.Expense.ShortTerm;
using IncomeViz.ProfitCalculation.Domain.Income.LongTerm;
using IncomeViz.ProfitCalculation.Domain.Income.ShortTerm;
using IncomeViz.ProfitCalculation.Domain.Prediction;
using IncomeViz.ProfitCalculation.Infrastructure.Database.Configurations;

namespace IncomeViz.ProfitCalculation.Infrastructure.Database
{
    public class ProfitCalculationDbContext : DbContext
    {
        internal DbSet<LongTermIncome> LongTermIncomes { get; set; }
        internal DbSet<ShortTermIncome> ShortTermIncomes { get; set; }
        internal DbSet<LongTermExpense> LongTermExpenses { get; set; }
        internal DbSet<ShortTermExpense> ShortTermExpenses { get; set; }
        internal DbSet<Prediction> Predictions { get; set; }

        public ProfitCalculationDbContext(DbContextOptions<ProfitCalculationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LongTermIncomesConfiguration());
            modelBuilder.ApplyConfiguration(new ShortTermIncomesConfiguration());
            modelBuilder.ApplyConfiguration(new LongTermExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new ShortTermExpensesConfiguration());
            modelBuilder.ApplyConfiguration(new PredictionsConfiguration());
        }
    }
}