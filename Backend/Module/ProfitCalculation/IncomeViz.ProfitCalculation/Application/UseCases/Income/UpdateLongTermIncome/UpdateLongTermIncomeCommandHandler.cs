using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Domain.Income.LongTerm;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.LongTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Income.UpdateLongTermIncome
{
    public class UpdateLongTermIncomeCommandHandler : IRequestHandler<UpdateLongTermIncomeCommand>
    {
        private readonly IWriteLongTermIncomeRepository _repository;

        public UpdateLongTermIncomeCommandHandler(IWriteLongTermIncomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateLongTermIncomeCommand command, CancellationToken cancellationToken)
        {
            var longTermIncome = await _repository.GetLongTermIncomeById(command.LongTermIncomeId);
            var update = new LongTermIncome(longTermIncome.PredictionId, command.Name, command.StartingDate,
                command.EffectiveDate, command.ExecutionDay, new Money(command.Amount, command.Currency));
            
            longTermIncome.Update(update);
            _repository.UpdateLongTermIncome(longTermIncome);
            await _repository.SaveAsync();

            return  Unit.Value;
        }
    }
}
