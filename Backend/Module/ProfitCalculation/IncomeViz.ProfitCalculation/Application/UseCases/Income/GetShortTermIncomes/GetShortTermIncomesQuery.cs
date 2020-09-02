﻿using System.Collections.Generic;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Income.GetShortTermIncomes
{
    public class GetShortTermIncomesQuery : IRequest<ICollection<ShortTermIncomeDto>>
    { }
}