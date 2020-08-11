using System;
using MediatR;
using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Funds;

namespace IncomeViz.ProfitCalculation.Application.UseCases.AddLongTermExpense
{
    public class AddLongTermExpenseCommand : IRequest
    {
        [Required] public Guid PredictionId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [NotNull]
        public string Name { get; set; }

        [Required] public DateTime StartingDate { get; set; }

        [Required] public int ExecutionDay { get; set; }

        [Required] public decimal Amount { get; set; }

        public Currency Currency { get; set; } = Currency.PLN;

        public DateTime? EffectiveDate { get; set; } = null;
    }
}