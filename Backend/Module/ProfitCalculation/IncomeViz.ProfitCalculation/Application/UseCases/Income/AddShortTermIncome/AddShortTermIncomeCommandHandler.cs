using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.ShortTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Income.AddShortTermIncome
{
    public class AddShortTermIncomeCommandHandler : IRequestHandler<AddShortTermIncomeCommand>
    {
        private readonly IWriteShortTermIncomeRepository _repository;

        public AddShortTermIncomeCommandHandler(IWriteShortTermIncomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddShortTermIncomeCommand command, CancellationToken cancellationToken)
        {
            var prediction = await _repository.GetPredictionById(command.PredictionId);

            prediction.AddShortTermIncome(command.Name,
                command.ExecutionDate,
                new Money(command.Amount, command.Currency));

            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
