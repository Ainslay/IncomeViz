using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.ShortTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Expense.DeleteShortTermExpense
{
    public class DeleteShortTermExpenseCommandHandler : IRequestHandler<DeleteShortTermExpenseCommand>
    {
        private readonly IWriteShortTermExpenseRepository _repository;

        public DeleteShortTermExpenseCommandHandler(IWriteShortTermExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteShortTermExpenseCommand command, CancellationToken cancellationToken)
        {
            await _repository.DeleteShortTermExpense(command.ShortTermExpenseId);
            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
