using System;
using MediatR;
using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Funds;

namespace IncomeViz.ProfitCalculation.Application.UseCases.AddPrediction
{
    public class AddPredictionCommand : IRequest<Guid>
    {
        [Required(AllowEmptyStrings = false)]
        [NotNull]
        public string Name { get; set; }

        [Required] public decimal Amount { get; set; }
        [Required] public Currency Currency { get; set; }
        [Required] public DateTime StartingDate { get; set; }
    }
}