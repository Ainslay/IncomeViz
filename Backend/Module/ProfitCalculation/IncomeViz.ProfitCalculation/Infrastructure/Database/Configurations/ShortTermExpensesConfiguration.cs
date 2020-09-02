using System;
using IncomeViz.ProfitCalculation.Domain.Expense.ShortTerm;
using IncomeViz.ProfitCalculation.Domain.Funds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IncomeViz.ProfitCalculation.Infrastructure.Database.Configurations
{
    public class ShortTermExpensesConfiguration : IEntityTypeConfiguration<ShortTermExpense>
    {
        public void Configure(EntityTypeBuilder<ShortTermExpense> builder)
        {
            builder.ToTable("ShortTermExpenses", "profitcalculation");
            builder.HasKey(income => income.Id);
            builder.Property<string>("_name").HasColumnName("Name");
            builder.Property<DateTime>("_executionDate").HasColumnName("ExecutionDate");
            builder.OwnsOne<Money>("_money", m =>
            {
                m.Property<decimal>("_amount").HasColumnName("Amount").HasColumnType("decimal(18, 2)");
                m.Property<Currency>("_currency").HasColumnName("Currency").HasConversion(new EnumToStringConverter<Currency>());
            });
        }
    }
}
