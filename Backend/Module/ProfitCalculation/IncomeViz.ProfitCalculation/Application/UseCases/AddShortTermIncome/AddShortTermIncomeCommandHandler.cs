using MediatR;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.ShortTerm;

namespace IncomeViz.ProfitCalculation.Application.UseCases.AddShortTermIncome
{
    public class AddShortTermIncomeCommandHandler : IRequestHandler<AddShortTermIncomeCommand>
    {
        private readonly IWriteShortTermIncomeRepository _repository;

        public AddShortTermIncomeCommandHandler(IWriteShortTermIncomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddShortTermIncomeCommand request, CancellationToken cancellationToken)
        {
            var prediction = await _repository.GetPredictionByPredictionId(request.PredictionId);

            prediction.AddShortTermIncome(request.Name,
                request.ExecutionDate,
                new Money(request.Amount, request.Currency));

            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}