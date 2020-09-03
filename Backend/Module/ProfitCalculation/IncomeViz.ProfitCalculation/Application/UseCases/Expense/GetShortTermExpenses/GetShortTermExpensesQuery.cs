using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Expense.GetShortTermExpenses
{
    public class GetShortTermExpensesQuery : IRequest<ICollection<ShortTermExpenseDto>>
    {
        [Required] public Guid PredictionId { get; set; }
    }
}
