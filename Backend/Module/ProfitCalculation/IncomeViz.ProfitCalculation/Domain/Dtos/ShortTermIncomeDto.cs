using System;
using IncomeViz.BuildingBlocks.ValidationHelpers;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Domain.Income.ShortTerm;

namespace IncomeViz.ProfitCalculation.Domain.Dtos
{
    public class ShortTermIncomeDto
    {
        public Guid ShortTermIncomeId { get; set; }
        public string Name { get; set; }
        public DateTime ExecutionDate { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }

        public ShortTermIncomeDto(ShortTermIncome income)
        {
            Check.NotNull(income, nameof(income));

            ShortTermIncomeId = income.EntityId;
            Name = income.GetName();
            ExecutionDate = income.GetExecutionDate();
            Amount = income.GetMoney().GetAmount();
            Currency = income.GetMoney().GetCurrency();
        }
    }
}
