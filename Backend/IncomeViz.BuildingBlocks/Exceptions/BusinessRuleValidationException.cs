using System;
using IncomeViz.BuildingBlocks.Domain;

namespace IncomeViz.BuildingBlocks.Exceptions
{
    public class BusinessRuleValidationException : Exception
    {
        public BusinessRuleValidationException(IBusinessRule rule) : base(rule.Message)
        { }
    }
}