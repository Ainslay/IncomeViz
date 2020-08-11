using IncomeViz.BuildingBlocks.Domain;
using IncomeViz.BuildingBlocks.ValidationHelpers;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Domain.Interfaces;
using System;

namespace IncomeViz.ProfitCalculation.Domain.Income.ShortTerm
{
    public class ShortTermIncome : Entity, IShortTerm
    {
        public int Id { get; set; }
        private string _name;
        private DateTime _executionDate;
        private Money _money;

        public int PredictionId { get; set; }
        public Prediction.Prediction Prediction { get; set; }

        private ShortTermIncome()
        {
            // Just for ef core
        }

        public ShortTermIncome(int predictionId, string name, DateTime executionDate, Money money)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.DateGreaterThan(executionDate, nameof(executionDate), DateTime.UtcNow.AddDays(-1));
            Check.PositiveNumber(predictionId, nameof(predictionId));
            PredictionId = predictionId;

            _name = name;
            _executionDate = executionDate;
            _money = money;
        }

        public string GetName()
        {
            return _name;
        }

        public DateTime GetExecutionDate()
        {
            return _executionDate.ToUniversalTime().Date;
        }
        public Money GetMoney()
        {
            return _money;
        }
    }
}