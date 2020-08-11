using MediatR;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.ShortTerm;

namespace IncomeViz.ProfitCalculation.Application.UseCases.AddShortTermExpense
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

        public async Task<Unit> Handle(AddShortTermExpenseCommand request, CancellationToken cancellationToken)
        {
            var prediction = await _repository.GetPredictionByPredictionId(request.PredictionId);

            prediction.AddShortTermExpense(
                request.Name,
                request.ExecutionDate,
                new Money(request.Amount, request.Currency));

            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}