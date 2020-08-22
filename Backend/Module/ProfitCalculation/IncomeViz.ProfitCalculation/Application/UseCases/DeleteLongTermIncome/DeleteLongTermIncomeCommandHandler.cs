using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.LongTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.DeleteLongTermIncome
{
    public class DeleteLongTermIncomeCommandHandler : IRequestHandler<DeleteLongTermIncomeCommand>
    {
        private IWriteLongTermIncomeRepository _repository;

        public DeleteLongTermIncomeCommandHandler(IWriteLongTermIncomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteLongTermIncomeCommand command, CancellationToken cancellationToken)
        {
            await _repository.DeleteLongTermIncome(command.LongTermIncomeId);
            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
