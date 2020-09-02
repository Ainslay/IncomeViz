using System;
using IncomeViz.BuildingBlocks.Domain;

namespace IncomeViz.ProfitCalculation.Domain.Prediction.Rules
{
    internal class EffectiveDateMustBeHigherThanStartingDateRule : IBusinessRule
    {
        public string Message { get; } = "Effective date must be higher than starting date.";
        private readonly DateTime? _effectiveDate;
        private readonly DateTime _startingDate;

        public EffectiveDateMustBeHigherThanStartingDateRule(DateTime? effectiveDate, DateTime startingDate)
        {
            _effectiveDate = effectiveDate;
            _startingDate = startingDate;
        }

        public bool IsBroken()
        {
            // Null effective date means not set end date -> infinite
            if (_effectiveDate == null)
            {
                return false;
            }

            return _effectiveDate.Value.Date <= _startingDate;
        }
    }
}
