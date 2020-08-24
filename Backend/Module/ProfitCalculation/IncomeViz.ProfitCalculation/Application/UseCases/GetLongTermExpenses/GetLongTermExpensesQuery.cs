using System.Collections.Generic;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.GetLongTermExpenses
{
    public class GetLongTermExpensesQuery : IRequest<ICollection<LongTermExpenseDto>>
    { }
}
