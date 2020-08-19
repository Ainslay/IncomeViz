using MediatR;
using System.Collections.Generic;
using IncomeViz.ProfitCalculation.Domain.Prediction;

namespace IncomeViz.ProfitCalculation.Application.UseCases.GetShortPredictions
{
    public class GetShortPredictionsQuery : IRequest<ICollection<PredictionDto>>
    { }
}
