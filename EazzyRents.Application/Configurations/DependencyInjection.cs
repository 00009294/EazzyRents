using EazzyRents.Application.Helper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EazzyRents.Application.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(typeof(AppMapper));
            //services.AddScoped<IRequestHandler<LoginQuery, ErrorOr<AuthResult>>, LoginQueryHandler>();
            //services.AddScoped<IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>, RegisterCommandHandler>();

            return services;
        }
    }
}
