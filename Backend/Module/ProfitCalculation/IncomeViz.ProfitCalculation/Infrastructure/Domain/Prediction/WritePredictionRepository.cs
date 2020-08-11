using System;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Infrastructure.Database;

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
    }
}