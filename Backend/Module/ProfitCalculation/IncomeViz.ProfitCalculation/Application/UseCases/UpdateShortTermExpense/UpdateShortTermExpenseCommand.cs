using System;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Funds;
using JetBrains.Annotations;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.UpdateShortTermExpense
{
    public class UpdateShortTermExpenseCommand : IRequest
    {
        [Required] public Guid ShortTermExpenseId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [NotNull]
        public string Name { get; set; }

        [Required] public DateTime ExecutionDate { get; set; }

        [Required] public decimal Amount { get; set; }

        [Required] public Currency Currency { get; set; }
    }
}
