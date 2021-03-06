﻿using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Expense.DeleteLongTermExpense
{
    public class DeleteLongTermExpenseCommand : IRequest
    {
        [Required] public Guid LongTermExpenseId { get; set; }
    }
}
