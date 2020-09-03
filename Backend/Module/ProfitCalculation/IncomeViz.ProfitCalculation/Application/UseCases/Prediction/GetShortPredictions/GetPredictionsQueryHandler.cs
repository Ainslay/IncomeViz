using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Prediction.GetShortPredictions
{
    public class GetPredictionsQueryHandler : IRequestHandler<GetPredictionsQuery, ICollection<PredictionDto>>
    {
        private readonly IReadPredictionRepository _repository;

        public GetPredictionsQueryHandler(IReadPredictionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<PredictionDto>> Handle(GetPredictionsQuery request,
            CancellationToken cancellationToken)
        {
            var predictions = await _repository.GetPredictions();

            return predictions.Select(prediction => new PredictionDto(prediction)).ToList();
        }
    }
}
