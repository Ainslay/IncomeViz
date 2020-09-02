using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.ShortTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Income.DeleteShortTermIncome
{
    public class DeleteShortTermIncomeCommandHandler : IRequestHandler<DeleteShortTermIncomeCommand>
    {
        private IWriteShortTermIncomeRepository _repository;

        public DeleteShortTermIncomeCommandHandler(IWriteShortTermIncomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteShortTermIncomeCommand command, CancellationToken cancellationToken)
        {
            await _repository.DeleteShortTermIncome(command.ShortTermIncomeId);
            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
