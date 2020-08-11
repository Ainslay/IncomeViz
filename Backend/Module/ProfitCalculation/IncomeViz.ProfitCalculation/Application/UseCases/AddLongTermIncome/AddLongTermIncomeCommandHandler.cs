using MediatR;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.LongTerm;

namespace IncomeViz.ProfitCalculation.Application.UseCases.AddLongTermIncome
{
    public class AddLongTermIncomeCommandHandler : IRequestHandler<AddLongTermIncomeCommand>
    {
        private readonly IWriteLongTermIncomeRepository _repository;

        public AddLongTermIncomeCommandHandler(IWriteLongTermIncomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddLongTermIncomeCommand request, CancellationToken cancellationToken)
        {
            var prediction = await _repository.GetPredictionByPredictionId(request.PredictionId);

            prediction.AddLongTermIncome(
                request.Name,
                request.StartingDate,
                request.EffectiveDate,
                request.ExecutionDay,
                new Money(request.Amount, request.Currency)
            );

            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}