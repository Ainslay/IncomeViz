using IncomeViz.BuildingBlocks.Exceptions;
using System;

namespace IncomeViz.BuildingBlocks.Domain
{
    public abstract class Entity
    {
        public Guid EntityId { get; set; } = Guid.NewGuid();

        protected void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken()) throw new BusinessRuleValidationException(rule);
        }
    }
}