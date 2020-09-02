using System;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Funds;
using JetBrains.Annotations;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Expense.UpdateLongTermExpense
{
    public class UpdateLongTermExpenseCommand : IRequest
    {
        [Required] public Guid LongTermExpenseId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [NotNull]
        public string Name { get; set; }

        [Required] public DateTime StartingDate { get; set; }

        [Required] public int ExecutionDay { get; set; }

        [Required] public decimal Amount { get; set; }

        [Required] public Currency Currency { get; set; }

        public DateTime? EffectiveDate { get; set; } = null;
    }
}
