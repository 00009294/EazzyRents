using EazzyRents.Application.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EazzyRents.Application.Configurations
{
      public static class DependencyInjection
      {
            public static IServiceCollection AddApplication(this IServiceCollection services,IConfiguration configuration)
            {
                  services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
                  services.AddAutoMapper(typeof(AppMapper));

                  return services;
            }
      }
}
