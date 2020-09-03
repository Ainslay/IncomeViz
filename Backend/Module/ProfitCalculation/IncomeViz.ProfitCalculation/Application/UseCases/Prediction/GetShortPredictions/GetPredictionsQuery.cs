using System.Collections.Generic;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Prediction.GetShortPredictions
{
    public class GetPredictionsQuery : IRequest<ICollection<PredictionDto>>
    {
    }
}
