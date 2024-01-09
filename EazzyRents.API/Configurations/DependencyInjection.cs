using EazzyRents.Application.Configurations;
using EazzyRents.Infrastructure.Configurations;

namespace EazzyRents.API.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAllDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructure(configuration);
            services.AddApplication();

            return services;
        }
    }
}
