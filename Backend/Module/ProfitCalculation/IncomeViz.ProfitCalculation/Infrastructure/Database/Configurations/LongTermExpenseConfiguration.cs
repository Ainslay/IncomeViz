using System;
using IncomeViz.ProfitCalculation.Domain.Expense.LongTerm;
using IncomeViz.ProfitCalculation.Domain.Funds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncomeViz.ProfitCalculation.Infrastructure.Database.Configurations
{
    internal class LongTermExpenseConfiguration : IEntityTypeConfiguration<LongTermExpense>
    {
        public void Configure(EntityTypeBuilder<LongTermExpense> builder)
        {
            builder.ToTable("LongTermExpenses", "profitcalculation");
            builder.HasKey(income => income.Id);
            builder.Property<string>("_name").HasColumnName("Name");
            builder.Property<int>("_executionDay").HasColumnName("ExecutionDay");
            builder.Property<DateTime>("_startingDate").HasColumnName("StartingDate");
            builder.Property<DateTime?>("_effectiveDate").HasColumnName("EffectiveDate");
            builder.OwnsOne<Money>("_money", m =>
            {
                m.Property<decimal>("_amount").HasColumnName("Amount").HasColumnType("decimal(18, 2)");
                m.Property<Currency>("_currency").HasColumnName("Currency");
            });
        }
    }
}
