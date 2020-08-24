using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Expense.ShortTerm;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.ShortTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.UpdateShortTermExpense
{
    public class UpdateShortTermExpenseCommandHandler : IRequestHandler<UpdateShortTermExpenseCommand>
    {
        private readonly IWriteShortTermExpenseRepository _repository;

        public UpdateShortTermExpenseCommandHandler(IWriteShortTermExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateShortTermExpenseCommand command, CancellationToken cancellationToken)
        {
            var shortTermExpense = await _repository.GetShortTermExpenseById(command.ShortTermExpenseId);
            var update = new ShortTermExpense(shortTermExpense.PredictionId, command.Name, command.ExecutionDate, new Money(command.Amount, command.Currency));

            shortTermExpense.Update(update);
            _repository.UpdateShortTermExpense(shortTermExpense);
            await _repository.SaveAsync();
            
            return Unit.Value;
        }
    }
}
