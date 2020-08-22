using System;
using MediatR;
using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Funds;

namespace IncomeViz.ProfitCalculation.Application.UseCases.AddLongTermIncome
{
    public class AddLongTermIncomeCommand : IRequest
    {
        [Required] public Guid PredictionId { get; set; }

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
