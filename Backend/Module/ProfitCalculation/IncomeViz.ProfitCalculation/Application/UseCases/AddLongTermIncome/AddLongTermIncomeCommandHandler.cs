using MediatR;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.LongTerm;

namespace IncomeViz.ProfitCalculation.Application.UseCases.AddLongTermIncome
{
    public class AddLongTermIncomeCommandHandler : IRequestHandler<AddLongTermIncomeCommand>
    {
        private readonly IWriteLongTermIncomeRepository _repository;

        public AddLongTermIncomeCommandHandler(IWriteLongTermIncomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddLongTermIncomeCommand command, CancellationToken cancellationToken)
        {
            var prediction = await _repository.GetPredictionById(command.PredictionId);

            prediction.AddLongTermIncome(
                command.Name,
                command.StartingDate,
                command.EffectiveDate,
                command.ExecutionDay,
                new Money(command.Amount, command.Currency)
            );

            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
