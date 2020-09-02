using System;
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

        public ShortTermExpenseDto(Guid shortTermExpenseId, string name, DateTime executionDate, decimal amount,
            Currency currency)
        {
            ShortTermExpenseId = shortTermExpenseId;
            Name = name;
            ExecutionDate = executionDate;
            Amount = amount;
            Currency = currency;
        }
    }
}
