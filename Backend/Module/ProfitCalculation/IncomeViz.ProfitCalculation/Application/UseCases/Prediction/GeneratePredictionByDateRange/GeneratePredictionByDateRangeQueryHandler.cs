﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Prediction;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Prediction.GeneratePredictionByDateRange
{
    public class
        GeneratePredictionByDateRangeQueryHandler : IRequestHandler<GeneratePredictionByDateRangeQuery,
            List<DateMoneyDto>>
    {
        private readonly IReadPredictionRepository _readPredictionRepository;

        public GeneratePredictionByDateRangeQueryHandler(IReadPredictionRepository readPredictionRepository)
        {
            _readPredictionRepository = readPredictionRepository;
        }

        public async Task<List<DateMoneyDto>> Handle(GeneratePredictionByDateRangeQuery request,
            CancellationToken cancellationToken)
        {
            var prediction = await _readPredictionRepository.GetFullPredictionById(request.PredictionId);
            var (minDate, maxDate) = GetDateRange(request.PredictionType);

            var result = prediction.GeneratePrediction(minDate, maxDate);

            return result;
        }

        private (DateTime, DateTime) GetDateRange(PredictionType predictionType)
        {
            var today = DateTime.Today.ToUniversalTime().Date;
            var predictionEnd = today;

            switch (predictionType)
            {
                case PredictionType.Weekly:
                    predictionEnd = today.AddDays(7);
                    break;
                case PredictionType.Monthly:
                    predictionEnd = today.AddDays(30);
                    break;
                case PredictionType.Yearly:
                    predictionEnd = today.AddDays(365);
                    break;
            }

            return (today, predictionEnd);
        }
    }
}
