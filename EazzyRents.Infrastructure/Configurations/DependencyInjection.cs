using Azure.Storage.Blobs;
using EazzyRents.Application.Common.Interfaces.Authentication;
using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Application.Common.Interfaces.Services;
using EazzyRents.Infrastructure.Authentication;
using EazzyRents.Infrastructure.Data;
using EazzyRents.Infrastructure.Persistence;
using EazzyRents.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EazzyRents.Infrastructure.Configurations
{
      public static class DependencyInjection
      {
            public static IServiceCollection AddInfrastructure (this IServiceCollection services, IConfiguration configuration)
            {
                  // Database connection
                  services.AddDbContext<AppDbContext>(options =>
                  {
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),

                      sqlServerOptions =>
                      {
                            sqlServerOptions.CommandTimeout(3600);
                            sqlServerOptions.EnableRetryOnFailure(60, TimeSpan.FromSeconds(60), null);
                      });
                  });
                  // Blob Storage connection
                  services.AddSingleton(x => new BlobServiceClient(configuration.GetConnectionString("AzureBlobConnectionString")));

                  // Services
                  services.AddScoped<IUserRepository, UserRepository>();
                  services.AddScoped<IRealEstateRepository, RealEstateRepository>();
                  services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
                  services.AddScoped<IDateTimerProvider, DateTimeProvider>();
                  services.AddScoped<IBlobService, BlobService>();

                  return services;
            }
      }
}
