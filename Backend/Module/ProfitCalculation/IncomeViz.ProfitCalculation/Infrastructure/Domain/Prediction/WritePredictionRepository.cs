using System;
using MediatR;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction
{
    public class WritePredictionRepository : IWritePredictionRepository
    {
        private readonly ProfitCalculationDbContext _db;

        public WritePredictionRepository(ProfitCalculationDbContext db)
        {
            _db = db;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<Unit> AddPrediction(ProfitCalculation.Domain.Prediction.Prediction prediction)
        {
            await _db.AddAsync(prediction);
            return  Unit.Value;
        }

        public async Task<Unit> DeletePredictionById(Guid predictionId)
        {
            var predictionToDelete = await _db.Predictions.SingleOrDefaultAsync(p => p.EntityId == predictionId)
                ?? throw new NullReferenceException(nameof(predictionId));

            _db.Predictions.Remove(predictionToDelete);

            return Unit.Value;
        }
    }
}
