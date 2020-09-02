using IncomeViz.BuildingBlocks.Domain;
using System;

namespace IncomeViz.ProfitCalculation.Domain.Prediction.Rules
{
    internal class StartingDateMustBeHigherThanEffectiveDateRule : IBusinessRule
    {
        private DateTime _startingDate;
        private DateTime? _effectiveDate;

        public StartingDateMustBeHigherThanEffectiveDateRule(DateTime startingDate, DateTime? effectiveDate)
        {
            _startingDate = startingDate;
            _effectiveDate = effectiveDate;
        }

        public string Message => "Expense or income starting date must be higher than effective date";

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
