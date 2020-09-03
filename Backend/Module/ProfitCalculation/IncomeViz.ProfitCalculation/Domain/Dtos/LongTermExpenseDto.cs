using System;
using IncomeViz.BuildingBlocks.ValidationHelpers;
using IncomeViz.ProfitCalculation.Domain.Expense.LongTerm;
using IncomeViz.ProfitCalculation.Domain.Funds;

namespace IncomeViz.ProfitCalculation.Domain.Dtos
{
    public class LongTermExpenseDto
    {
        public Guid LongTermExpenseId { get; set; }
        public string Name { get; set; }
        public int ExecutionDay { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }

        public LongTermExpenseDto(LongTermExpense expense)
        {
            Check.NotNull(expense, nameof(expense));

            LongTermExpenseId = expense.EntityId;
            Name = expense.GetName();
            ExecutionDay = expense.GetExecutionDay();
            StartingDate = expense.GetStartingDate();
            EffectiveDate = expense.GetEffectiveDate();
            Amount = expense.GetMoney().GetAmount();
            Currency = expense.GetMoney().GetCurrency();
        }
    }
}
