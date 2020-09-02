using System;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Funds;
using JetBrains.Annotations;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Prediction.AddPrediction
{
    public class AddPredictionCommand : IRequest<Unit>
    {
        [Required(AllowEmptyStrings = false)]
        [NotNull]
        public string Name { get; set; }

        [Required] public decimal Amount { get; set; }
        [Required] public Currency Currency { get; set; }
        [Required] public DateTime StartingDate { get; set; }
    }
}
