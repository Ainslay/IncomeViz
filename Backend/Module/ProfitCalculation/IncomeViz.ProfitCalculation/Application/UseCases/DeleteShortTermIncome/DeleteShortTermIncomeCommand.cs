﻿using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.DeleteShortTermIncome
{
    public class DeleteShortTermIncomeCommand : IRequest
    {
        [Required] public Guid ShortTermIncomeId { get; set; }
    }
}
