using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Prediction;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Prediction.GeneratePredictionByDateRange
{
    public class GeneratePredictionByDateRangeQuery: IRequest<List<DateMoneyDto>>
    {
        [Required]
        public Guid PredictionId { get; set; }

        [Required]
        public PredictionType PredictionType { get; set; }
    }
}
