using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.DeletePrediction
{
    class DeletePredictionCommandHandler : IRequestHandler<DeletePredictionCommand>
    {
        private IWritePredictionRepository _repository;

        public DeletePredictionCommandHandler(IWritePredictionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePredictionCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAndSave(request.Id);
            return Unit.Value;
        }
    }
}
