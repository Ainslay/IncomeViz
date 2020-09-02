using IncomeViz.BuildingBlocks.Domain;
using IncomeViz.BuildingBlocks.ValidationHelpers;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Domain.Interfaces;
using System;

namespace IncomeViz.ProfitCalculation.Domain.Expense.ShortTerm
{
    public class ShortTermExpense : Entity, IShortTerm
    {
        public int Id { get; set; }
        private string _name;
        private DateTime _executionDate;
        private Money _money;

        public int PredictionId { get; set; }
        public Prediction.Prediction Prediction { get; set; }

        private ShortTermExpense()
        {
            // Just for ef core
        }

        public ShortTermExpense(int predictionId, string name, DateTime executionDate, Money money)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.DateGreaterThan(executionDate, nameof(executionDate), DateTime.UtcNow.AddDays(-1));
            Check.PositiveNumber(predictionId, nameof(predictionId));
            PredictionId = predictionId;

            _name = name;
            _executionDate = executionDate;
            _money = money;
        }

        public void Update(ShortTermExpense update)
        {
            _name = update._name;
            _money = update._money;
            _executionDate = update._executionDate;
        }

        public string GetName()
        {
            return _name;
        }

        public DateTime GetExecutionDate()
        {
            return _executionDate.Date.ToUniversalTime();
        }

        public Money GetMoney()
        {
            return _money;
        }
    }
}
