using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.LongTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.DeleteLongTermExpense
{
    public class DeleteLongTermExpenseCommandHandler : IRequestHandler<DeleteLongTermExpenseCommand>
    {
        private readonly IWriteLongTermExpenseRepository _repository;

        public DeleteLongTermExpenseCommandHandler(IWriteLongTermExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteLongTermExpenseCommand command, CancellationToken cancellationToken)
        {
            await _repository.DeleteLongTermExpense(command.LongTermExpenseId);
            await _repository.SaveAsync();

            return  Unit.Value;
        }
    }
}
