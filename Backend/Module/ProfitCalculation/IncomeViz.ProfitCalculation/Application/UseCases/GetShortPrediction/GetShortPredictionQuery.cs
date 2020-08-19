using System;
using MediatR;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Prediction;

namespace IncomeViz.ProfitCalculation.Application.UseCases.GetPrediction
{
    public class GetShortPredictionQuery : IRequest<PredictionDto>
    {
        [Required] public Guid Id { get; set; }
    }
}
