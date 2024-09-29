using ContactManager.Service.Implementations;
using ContactManager.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManager.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IResumeManagerService, ResumeManagerService>();

            return services;
        }
    }
}
