using System;
using IncomeViz.ProfitCalculation.Domain.Funds;

namespace IncomeViz.ProfitCalculation.Domain.Prediction
{
    public class PredictionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
        public DateTime StartingDate { get; set; }

        public PredictionDto(Guid id, string name, decimal amount, Currency currency, DateTime startingDate)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Currency = currency;
            StartingDate = startingDate;
        }
    }
}
