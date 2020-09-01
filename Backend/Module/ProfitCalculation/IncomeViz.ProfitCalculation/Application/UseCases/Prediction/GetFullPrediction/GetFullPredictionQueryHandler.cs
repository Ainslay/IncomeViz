using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Prediction.GetFullPrediction
{
    internal class GetFullPredictionQueryHandler : IRequestHandler<GetFullPredictionQuery, FullPredictionDto>
    {
        private readonly IReadPredictionRepository _repository;

        public GetFullPredictionQueryHandler(IReadPredictionRepository repository)
        {
            _repository = repository;
        }

        public async Task<FullPredictionDto> Handle(GetFullPredictionQuery query, CancellationToken cancellationToken)
        {
            var p = await _repository.GetFullPredictionById(query.Id);

            var shortTermIncomesDto = p.ShortTermIncomes.Select(income => new ShortTermIncomeDto(income.EntityId,
                income.GetName(), income.GetExecutionDate(), income.GetMoney().GetAmount(),
                income.GetMoney().GetCurrency())).ToList();

            var longTermIncomesDto = p.LongTermIncomes.Select(income => new LongTermIncomeDto(income.EntityId,
                income.GetName(), income.GetExecutionDay(), income.GetStartingDate(), income.GetEffectiveDate(),
                income.GetMoney().GetAmount(), income.GetMoney().GetCurrency())).ToList();

            var shortTermExpensesDto = p.ShortTermExpenses.Select(expense => new ShortTermExpenseDto(expense.EntityId,
                expense.GetName(), expense.GetExecutionDate(), expense.GetMoney().GetAmount(),
                expense.GetMoney().GetCurrency())).ToList();

            var longTermExpensesDto = p.LongTermExpenses.Select(expense => new LongTermExpenseDto(expense.EntityId,
                expense.GetName(),
                expense.GetExecutionDay(), expense.GetStartingDate(), expense.GetEffectiveDate(),
                expense.GetMoney().GetAmount(), expense.GetMoney().GetCurrency())).ToList();

            var predictionDto = new FullPredictionDto(p.EntityId, p.GetName(), p.GetStartingMoney().GetAmount(),
                p.GetStartingMoney().GetCurrency().ToString(), p.GetStartingDate(),
                shortTermIncomesDto, longTermIncomesDto, shortTermExpensesDto, longTermExpensesDto);

            return predictionDto;
        }
    }
}
