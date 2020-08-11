using System;
using MediatR;
using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Funds;

namespace IncomeViz.ProfitCalculation.Application.UseCases.AddShortTermExpense
{
    public class AddShortTermExpenseCommand : IRequest
    {
        [Required] public Guid PredictionId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [NotNull]
        public string Name { get; set; }

        [Required] public DateTime ExecutionDate { get; set; }

        [Required] public decimal Amount { get; set; }

        public Currency Currency { get; set; } = Currency.PLN;
    }
}