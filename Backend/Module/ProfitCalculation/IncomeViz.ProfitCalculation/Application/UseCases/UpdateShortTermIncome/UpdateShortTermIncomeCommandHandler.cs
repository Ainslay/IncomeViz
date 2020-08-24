using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Domain.Income.ShortTerm;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.ShortTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.UpdateShortTermIncome
{
    public class UpdateShortTermIncomeCommandHandler : IRequestHandler<UpdateShortTermIncomeCommand>
    {
        private readonly IWriteShortTermIncomeRepository _repository;

        public UpdateShortTermIncomeCommandHandler(IWriteShortTermIncomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateShortTermIncomeCommand command, CancellationToken cancellationToken)
        {
            var shortTermIncome = await _repository.GetShortTermIncomeById(command.ShortTermIncomeId);
            var update = new ShortTermIncome(shortTermIncome.PredictionId, command.Name,
                command.ExecutionDate, new Money(command.Amount, command.Currency))
            {
                EntityId = command.ShortTermIncomeId
            };

            shortTermIncome.Update(update);
            _repository.UpdateShortTermIncome(shortTermIncome);
            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}
