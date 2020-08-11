using System;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Prediction;

namespace IncomeViz.ProfitCalculation.Application.UseCases.GeneratePredictionByDateRange
{
    public class GeneratePredictionByDateRangeQuery: IRequest<List<DateMoneyDto>>
    {
        [Required]
        public Guid PredictionId { get; set; }

        [Required]
        public PredictionType PredictionType { get; set; }
    }
}
