using MediatR;
using System.Collections.Generic;
using IncomeViz.ProfitCalculation.Domain.Dtos;

namespace IncomeViz.ProfitCalculation.Application.UseCases.GetShortTermExpenses
{
    public class GetShortTermExpensesQuery : IRequest<ICollection<ShortTermExpenseDto>>
    { }
}
