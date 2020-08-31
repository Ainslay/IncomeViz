using System;
using System.Collections.Generic;

namespace IncomeViz.ProfitCalculation.Domain.Dtos
{
    public class FullPredictionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime StartingDate { get; set; }
        public ICollection<ShortTermIncomeDto> ShortTermIncomes { get; set; }
        public ICollection<LongTermIncomeDto> LongTermIncomes { get; set; }
        public ICollection<ShortTermExpenseDto> ShortTermExpenses { get; set; }
        public ICollection<LongTermExpenseDto> LongTermExpenses { get; set; }
        
        public FullPredictionDto(Guid id, string name, decimal amount, string currency, DateTime startingDate,
            ICollection<ShortTermIncomeDto> shortTermIncomes, ICollection<LongTermIncomeDto> longTermIncomes,
            ICollection<ShortTermExpenseDto> shortTermExpenses, ICollection<LongTermExpenseDto> longTermExpenses)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Currency = currency;
            StartingDate = startingDate;
            ShortTermIncomes = shortTermIncomes;
            LongTermIncomes = longTermIncomes;
            ShortTermExpenses = shortTermExpenses;
            LongTermExpenses = longTermExpenses;
        }
    }
}
