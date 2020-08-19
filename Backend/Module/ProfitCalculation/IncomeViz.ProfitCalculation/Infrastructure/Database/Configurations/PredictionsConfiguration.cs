using System;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Domain.Prediction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IncomeViz.ProfitCalculation.Infrastructure.Database.Configurations
{
    internal class PredictionsConfiguration : IEntityTypeConfiguration<Prediction>
    {
        public void Configure(EntityTypeBuilder<Prediction> builder)
        {
            builder.ToTable("Predictions", "profitcalculation");
            builder.HasKey(p => p.Id);
            builder.Property<string>("_name").HasColumnName("Name");

            builder.OwnsOne<Money>("_startingMoney", m =>
            {
                m.Property<decimal>("_amount").HasColumnName("Amount").HasColumnType("decimal(18, 2)");
                m.Property<Currency>("_currency").HasColumnName("Currency").HasConversion(new EnumToStringConverter<Currency>());
            });

            builder.Property<DateTime>("_startingDate").HasColumnName("StartingDate");

            var shortTermNavigation = builder.Metadata.FindNavigation(nameof(Prediction.ShortTermIncomes));
            shortTermNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var longTermIncomes = builder.Metadata.FindNavigation(nameof(Prediction.LongTermIncomes));
            longTermIncomes.SetPropertyAccessMode(PropertyAccessMode.Field);

            var shortTermExpenses = builder.Metadata.FindNavigation(nameof(Prediction.ShortTermExpenses));
            shortTermExpenses.SetPropertyAccessMode(PropertyAccessMode.Field);

            var longTermExpenses = builder.Metadata.FindNavigation(nameof(Prediction.LongTermExpenses));
            longTermExpenses.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
