using System;

namespace IncomeViz.ProfitCalculation.Domain.Dtos
{
    public class PredictionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime StartingDate { get; set; }

        public PredictionDto(Guid id, string name, decimal amount, string currency, DateTime startingDate)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Currency = currency;
            StartingDate = startingDate;
        }
    }
}
