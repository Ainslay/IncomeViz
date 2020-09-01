using System;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Prediction.GetFullPrediction
{
    public class GetFullPredictionQuery : IRequest<FullPredictionDto>
    {
        [Required] public Guid Id { get; set; }
    }
}
