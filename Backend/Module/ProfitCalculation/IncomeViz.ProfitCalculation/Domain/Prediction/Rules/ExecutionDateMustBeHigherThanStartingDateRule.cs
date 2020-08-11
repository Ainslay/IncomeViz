using System;
using IncomeViz.BuildingBlocks.Domain;

namespace IncomeViz.ProfitCalculation.Domain.Prediction.Rules
{
    internal class ExecutionDateMustBeHigherOrEqualThanStartingDateRule : IBusinessRule
    {
        private readonly DateTime _executionDate;
        private readonly DateTime _startingDate;

        public ExecutionDateMustBeHigherOrEqualThanStartingDateRule(DateTime executionDate, DateTime startingDate)
        {
            _executionDate = executionDate;
            _startingDate = startingDate;
        }

        public string Message { get; } = "Execution date must be higher than starting date";

        public bool IsBroken()
        {
            return _executionDate.Date < _startingDate.Date;
        }
    }
}