using System;
using IncomeViz.ProfitCalculation.Domain.Funds;

namespace IncomeViz.ProfitCalculation.Domain.Dtos
{
    public class ShortTermIncomeDto
    {
        public Guid ShorTermIncomeId { get; set; }
        public string Name { get; set; }
        public DateTime ExecutionDate { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
        
        public ShortTermIncomeDto(Guid shorTermIncomeId, string name, DateTime executionDate, decimal amount, Currency currency)
        {
            ShorTermIncomeId = shorTermIncomeId;
            Name = name;
            ExecutionDate = executionDate;
            Amount = amount;
            Currency = currency;
        }
    }
}
