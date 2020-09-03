using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Prediction.GetPrediction
{
    public class GetPredictionQueryHandler : IRequestHandler<GetPredictionQuery, PredictionDto>
    {
        private readonly IReadPredictionRepository _repository;

        public GetPredictionQueryHandler(IReadPredictionRepository repository)
        {
            _repository = repository;
        }

        public async Task<PredictionDto> Handle(GetPredictionQuery query, CancellationToken cancellationToken)
        {
            var prediction = await _repository.GetPredictionById(query.Id);

            return new PredictionDto(prediction);
        }
    }
}
