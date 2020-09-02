using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Prediction;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Prediction.GetShortPredictions
{
    public class GetShortPredictionsQueryHandler : IRequestHandler<GetShortPredictionsQuery, ICollection<PredictionDto>>
    {
        private readonly IReadPredictionRepository _repository;

        public GetShortPredictionsQueryHandler(IReadPredictionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<PredictionDto>> Handle(GetShortPredictionsQuery request, CancellationToken cancellationToken)
        {
            var predictions = await _repository.GetShortPredictions();

            return predictions.Select(prediction => new PredictionDto(prediction.EntityId, prediction.GetName(),
                prediction.GetStartingMoney().GetAmount(), prediction.GetStartingMoney().GetCurrency().ToString(),
                prediction.GetStartingDate())).ToList();
        }
    }
}
