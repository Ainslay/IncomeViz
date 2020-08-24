using MediatR;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.LongTerm;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.ShortTerm;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.LongTerm;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.ShortTerm;
using IncomeViz.ProfitCalculation.Infrastructure.Database;

namespace IncomeViz.ProfitCalculation
{
    public static class ModuleInstallation
    {
        public static void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IWriteLongTermIncomeRepository, WriteLongTermIncomeRepository>();
            services.AddScoped<IWriteShortTermIncomeRepository, WriteShortTermIncomeRepository>();
            services.AddScoped<IWriteLongTermExpenseRepository, WriteLongTermExpenseRepository>();
            services.AddScoped<IWriteShortTermExpenseRepository, WriteShortTermExpenseRepository>();
            services.AddScoped<IWritePredictionRepository, WritePredictionRepository>();
            services.AddScoped<IReadPredictionRepository, ReadPredictionRepository>();
            services.AddScoped<IReadShortTermIncomeRepository, ReadShortTermIncomeRepository>();
            services.AddScoped<IReadLongTermIncomeRepository, ReadLongTermIncomesRepository>();
            services.AddScoped<IReadShortTermExpenseRepository, ReadShortTermExpenseRepository>();

            services.AddDbContext<ProfitCalculationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ProfitCalculationDbContext")));
        }
    }
}
