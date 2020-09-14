using System;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Prediction.UpdatePrediction
{
    class UpdatePredictionCommandHandler : IRequestHandler<UpdatePredictionCommand>
    {
        private readonly IWritePredictionRepository _repository;

        public UpdatePredictionCommandHandler(IWritePredictionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdatePredictionCommand request, CancellationToken cancellationToken)
        {
            var prediction = await _repository.GetPredictionById(request.Id);
            var update = new Domain.Prediction.Prediction(request.Name, new Money(request.Amount, request.Currency), request.StartingDate);

            prediction.Update(update);
            _repository.UpdatePrediction(prediction);
            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
