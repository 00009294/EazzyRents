using EazzyRents.Application.Authentication.Commands;
using EazzyRents.Application.Authentication.Common;
using EazzyRents.Application.Authentication.Queries;
using EazzyRents.Application.Configurations;
using EazzyRents.Infrastructure.Configurations;
using ErrorOr;
using MediatR;
using System.Reflection;

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
