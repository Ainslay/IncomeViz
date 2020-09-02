﻿using System;
using IncomeViz.ProfitCalculation.Domain.Funds;

namespace IncomeViz.ProfitCalculation.Domain.Dtos
{
    public class ShortTermIncomeDto
    {
        public Guid ShortTermIncomeId { get; set; }
        public string Name { get; set; }
        public DateTime ExecutionDate { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }

        public ShortTermIncomeDto(Guid shortTermIncomeId, string name, DateTime executionDate, decimal amount,
            Currency currency)
        {
            ShortTermIncomeId = shortTermIncomeId;
            Name = name;
            ExecutionDate = executionDate;
            Amount = amount;
            Currency = currency;
        }
    }
}
