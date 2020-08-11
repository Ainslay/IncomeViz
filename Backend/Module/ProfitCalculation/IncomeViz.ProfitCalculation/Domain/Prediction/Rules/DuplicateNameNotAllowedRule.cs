using System.Collections.Generic;
using System.Linq;
using IncomeViz.BuildingBlocks.Domain;

namespace IncomeViz.ProfitCalculation.Domain.Prediction.Rules
{
    internal class DuplicateNameNotAllowedRule : IBusinessRule
    {
        private readonly string _name;
        private readonly IReadOnlyCollection<Interfaces.IQueryable> _incomes;
        public string Message { get; } = "Duplicate long term income names are not allowed";

        public DuplicateNameNotAllowedRule(string name, IReadOnlyCollection<Interfaces.IQueryable> incomes)
        {
            _name = name;
            _incomes = incomes;
        }

        public bool IsBroken()
        {
            return _incomes.Select(i => i.GetName()).Any(n => n.Equals(_name));
        }
    }
}