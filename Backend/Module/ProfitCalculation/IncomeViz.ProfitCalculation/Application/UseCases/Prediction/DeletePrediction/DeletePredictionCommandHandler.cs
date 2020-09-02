using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Prediction.DeletePrediction
{
    class DeletePredictionCommandHandler : IRequestHandler<DeletePredictionCommand>
    {
        private readonly IWritePredictionRepository _repository;

        public DeletePredictionCommandHandler(IWritePredictionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePredictionCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeletePredictionById(request.Id);
            await _repository.SaveAsync();
            return Unit.Value;
        }
    }
}
