using IncomeViz.BuildingBlocks.Domain;
using IncomeViz.BuildingBlocks.ValidationHelpers;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Domain.Interfaces;
using System;

namespace IncomeViz.ProfitCalculation.Domain.Income.LongTerm
{
    public class LongTermIncome : Entity, ILongTerm
    {
        public int Id { get; set; }
        private string _name;
        private int _executionDay;

        private DateTime _startingDate;
        private DateTime? _effectiveDate;
        private Money _money;

        public int PredictionId { get; set; }
        public Prediction.Prediction Prediction { get; set; }

        private LongTermIncome()
        {
            // Just for ef core
        }

        public LongTermIncome(int predictionId, string name, DateTime startingDate, DateTime? effectiveDate, int executionDay, Money money)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.PositiveNumber(predictionId, nameof(predictionId));
            PredictionId = predictionId;

            _name = name;
            _startingDate = startingDate;
            _effectiveDate = effectiveDate ?? DateTime.MaxValue.ToUniversalTime();
            _executionDay = executionDay;
            _money = money;
        }

        public string GetName() => _name;

        public int GetExecutionDay() => _executionDay;

        public DateTime GetStartingDate() =>  _startingDate;

        public DateTime? GetEffectiveDate() => _effectiveDate;

        public bool IsDateInValidRange(DateTime date)
        {
            return date.Date >= _startingDate && date.Date <= _effectiveDate;
        }

        public Money GetMoney()
        {
            return _money;
        }

        public void Update(LongTermIncome update)
        {
            _name = update._name;
            _money = update._money;
            _startingDate = update._startingDate;
            _effectiveDate = update._effectiveDate;
            _executionDay = update._executionDay;
        }
    }
}
