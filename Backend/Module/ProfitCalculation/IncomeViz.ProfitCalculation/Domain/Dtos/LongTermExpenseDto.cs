﻿using System;
using IncomeViz.ProfitCalculation.Domain.Funds;

namespace IncomeViz.ProfitCalculation.Domain.Dtos
{
    public class LongTermExpenseDto
    {
        public Guid LongTermExpenseId { get; set; }
        public string Name { get; set; }
        public int ExecutionDay { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }

        public LongTermExpenseDto(Guid longTermExpenseId, string name, int executionDay,
            DateTime startingDate, DateTime? effectiveDate, decimal amount, Currency currency)
        {
            LongTermExpenseId = longTermExpenseId;
            Name = name;
            ExecutionDay = executionDay;
            StartingDate = startingDate;
            EffectiveDate = effectiveDate;
            Amount = amount;
            Currency = currency;
        }
    }
}