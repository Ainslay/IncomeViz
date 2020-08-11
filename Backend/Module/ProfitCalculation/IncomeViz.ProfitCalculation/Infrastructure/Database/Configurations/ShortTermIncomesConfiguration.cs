using System;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Domain.Income.ShortTerm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncomeViz.ProfitCalculation.Infrastructure.Database.Configurations
{
    internal class ShortTermIncomesConfiguration : IEntityTypeConfiguration<ShortTermIncome>
    {
        public void Configure(EntityTypeBuilder<ShortTermIncome> builder)
        {
            builder.ToTable("ShortTermIncomes", "profitcalculation");
            builder.HasKey(income => income.Id);
            builder.Property<string>("_name").HasColumnName("Name");
            builder.Property<DateTime>("_executionDate").HasColumnName("ExecutionDate");
            builder.OwnsOne<Money>("_money", m =>
            {
                m.Property<decimal>("_amount").HasColumnName("Amount").HasColumnType("decimal(18, 2)");
                m.Property<Currency>("_currency").HasColumnName("Currency");
            });
        }
    }
}