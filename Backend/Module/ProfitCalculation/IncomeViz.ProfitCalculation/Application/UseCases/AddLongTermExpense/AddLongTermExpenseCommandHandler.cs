using MediatR;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.LongTerm;

namespace IncomeViz.ProfitCalculation.Application.UseCases.AddLongTermExpense
{
    internal class AddLongTermExpenseCommandHandler : IRequestHandler<AddLongTermExpenseCommand>
    {
        private readonly IWriteLongTermExpenseRepository _repository;

        public AddLongTermExpenseCommandHandler(IWriteLongTermExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddLongTermExpenseCommand request, CancellationToken cancellationToken)
        {
            var prediction = await _repository.GetPredictionByPredictionId(request.PredictionId);

            prediction.AddLongTermExpense(
                request.Name,
                request.StartingDate,
                request.EffectiveDate,
                request.ExecutionDay,
                new Money(request.Amount, request.Currency));

            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}