using EazzyRents.Application.Helper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EazzyRents.Application.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(typeof(AppMapper));




            return services;
        }
    }
}
