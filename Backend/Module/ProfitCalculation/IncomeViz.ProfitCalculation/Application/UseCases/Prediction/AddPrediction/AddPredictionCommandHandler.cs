using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Prediction.AddPrediction
{
    public class AddPredictionCommandHandler : IRequestHandler<AddPredictionCommand>
    {
        private readonly IWritePredictionRepository _repository;

        public AddPredictionCommandHandler(IWritePredictionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddPredictionCommand request, CancellationToken cancellationToken)
        {
            var prediction = new Domain.Prediction.Prediction(request.Name, new Money(request.Amount, request.Currency),
                request.StartingDate);

            await _repository.AddPrediction(prediction);
            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
