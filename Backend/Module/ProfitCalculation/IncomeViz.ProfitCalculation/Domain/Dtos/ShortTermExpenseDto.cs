using System;
using IncomeViz.ProfitCalculation.Domain.Expense.ShortTerm;
using IncomeViz.ProfitCalculation.Domain.Funds;

namespace IncomeViz.ProfitCalculation.Domain.Dtos
{
    public class ShortTermExpenseDto
    {
        public Guid ShortTermExpenseId { get; set; }
        public string Name { get; set; }
        public DateTime ExecutionDate { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }

        public ShortTermExpenseDto(ShortTermExpense expense)
        {
            ShortTermExpenseId = expense.EntityId;
            Name = expense.GetName();
            ExecutionDate = expense.GetExecutionDate();
            Amount = expense.GetMoney().GetAmount();
            Currency = expense.GetMoney().GetCurrency();
        }
    }
}
