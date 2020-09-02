using System;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Prediction.GetShortPrediction
{
    public class GetShortPredictionQuery : IRequest<PredictionDto>
    {
        [Required] public Guid Id { get; set; }
    }
}
