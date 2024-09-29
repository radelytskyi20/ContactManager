using ContactManager.Domain.Constants;
using ContactManager.Domain.Interfaces;
using ContactManager.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManager.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(ConnectionNames.DbConnection));
            });

            services.AddTransient<IResumeRepository, ResumeRepository>();

            return services;
        }
    }
}
