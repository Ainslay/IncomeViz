using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Application.UseCases.GetPrediction;
using IncomeViz.ProfitCalculation.Domain.Prediction;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.GetShortPrediction
{
    public class GetShortPredictionQueryHandler : IRequestHandler<GetShortPredictionQuery, PredictionDto>
    {
        private readonly IReadPredictionRepository _repository;

        public GetShortPredictionQueryHandler(IReadPredictionRepository repository)
        {
            _repository = repository;
        }

        public async Task<PredictionDto> Handle(GetShortPredictionQuery query, CancellationToken cancellationToken)
        {
            var prediction = await _repository.GetShortPredictionById(query.Id);

            return new PredictionDto(prediction.EntityId, prediction.GetName(), prediction.GetStartingMoney().GetAmount(),
                prediction.GetStartingMoney().GetCurrency().ToString(), prediction.GetStartingDate());
        }
    }
}
