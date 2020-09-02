using System.Collections.Generic;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Expense.GetShortTermExpenses
{
    public class GetShortTermExpensesQuery : IRequest<ICollection<ShortTermExpenseDto>>
    { }
}
