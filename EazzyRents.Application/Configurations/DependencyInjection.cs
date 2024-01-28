using Azure.Storage.Blobs;
using EazzyRents.Application.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EazzyRents.Application.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(typeof(AppMapper));

            services.AddSingleton(
                x =>
                new BlobServiceClient(
                        configuration.GetValue<string>("AzureBlobStorageSettings:ConnectionString")
                        // ConnectionString for azure blobStorage is still in-progress
                    )
            );


            return services;
        }
    }
}
