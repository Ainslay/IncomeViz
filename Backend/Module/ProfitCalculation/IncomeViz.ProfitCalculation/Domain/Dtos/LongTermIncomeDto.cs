using System;
using IncomeViz.BuildingBlocks.ValidationHelpers;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Domain.Income.LongTerm;

namespace IncomeViz.ProfitCalculation.Domain.Dtos
{
    public class LongTermIncomeDto
    {
        public Guid LongTermIncomeId { get; set; }
        public string Name { get; set; }
        public int ExecutionDay { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }

        public LongTermIncomeDto(LongTermIncome income)
        {
            Check.NotNull(income, nameof(income));

            LongTermIncomeId = income.EntityId;
            Name = income.GetName();
            ExecutionDay = income.GetExecutionDay();
            StartingDate = income.GetStartingDate();
            EffectiveDate = income.GetEffectiveDate();
            Amount = income.GetMoney().GetAmount();
            Currency = income.GetMoney().GetCurrency();
        }
    }
}
