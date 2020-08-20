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

        public async Task<Guid> AddAndSave(ProfitCalculation.Domain.Prediction.Prediction prediction)
        {
            await _db.AddAsync(prediction);
            await _db.SaveChangesAsync();

            return prediction.EntityId;
        }

        public async Task<Unit> DeleteAndSave(Guid predictionId)
        {
            var predictionToDelete = await _db.Predictions.SingleOrDefaultAsync(p => p.EntityId == predictionId);

            if(predictionToDelete != null)
            {
                _db.Predictions.Remove(predictionToDelete);
                await _db.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
