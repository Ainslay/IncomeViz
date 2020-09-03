using System;
using IncomeViz.ProfitCalculation.Domain.Funds;

namespace IncomeViz.ProfitCalculation.Domain.Dtos
{
    public class PredictionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
        public DateTime StartingDate { get; set; }

        public PredictionDto(Prediction.Prediction prediction)
        {
            Id = prediction.EntityId;
            Name = prediction.GetName();
            Amount = prediction.GetStartingMoney().GetAmount();
            Currency = prediction.GetStartingMoney().GetCurrency();
            StartingDate = prediction.GetStartingDate();
        }
    }
}
