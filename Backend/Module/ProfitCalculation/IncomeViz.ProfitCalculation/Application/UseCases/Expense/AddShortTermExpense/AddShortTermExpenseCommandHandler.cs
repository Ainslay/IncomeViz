using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.ShortTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Expense.AddShortTermExpense
{
    public class AddShortTermExpenseCommandHandler : IRequestHandler<AddShortTermExpenseCommand>
    {
        private readonly IWriteShortTermExpenseRepository _repository;
        private readonly IMediator _mediator;

        public AddShortTermExpenseCommandHandler(IWriteShortTermExpenseRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(AddShortTermExpenseCommand command, CancellationToken cancellationToken)
        {
            var prediction = await _repository.GetPredictionByPredictionId(command.PredictionId);

            prediction.AddShortTermExpense(
                command.Name,
                command.ExecutionDate,
                new Money(command.Amount, command.Currency));

            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
