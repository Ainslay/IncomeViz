using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Expense.GetLongTermExpenses
{
    public class GetLongTermExpensesQuery : IRequest<ICollection<LongTermExpenseDto>>
    {
        [Required] public Guid PredictionId { get; set; }
    }
}
