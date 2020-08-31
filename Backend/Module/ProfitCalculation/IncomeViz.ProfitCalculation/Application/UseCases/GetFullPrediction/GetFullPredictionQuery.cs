using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.GetFullPrediction
{
    public class GetFullPredictionQuery : IRequest<FullPredictionDto>
    {
        [Required] public Guid PredictionId { get; set; }
    }
}
