using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Expense.LongTerm;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.LongTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.UpdateLongTermExpense
{
    public class UpdateLongTermExpenseCommandHandler : IRequestHandler<UpdateLongTermExpenseCommand>
    {
        private readonly IWriteLongTermExpenseRepository _repository;

        public UpdateLongTermExpenseCommandHandler(IWriteLongTermExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateLongTermExpenseCommand command, CancellationToken cancellationToken)
        {
            var longTermExpense = await _repository.GetLongTermExpenseById(command.LongTermExpenseId);
            var update = new LongTermExpense(longTermExpense.PredictionId, command.Name, command.StartingDate,
                command.EffectiveDate, command.ExecutionDay, new Money(command.Amount, command.Currency));

            longTermExpense.Update(update);
            _repository.UpdateLongTermExpense(longTermExpense);
            await _repository.SaveAsync();

            return  Unit.Value;
        }
    }
}
