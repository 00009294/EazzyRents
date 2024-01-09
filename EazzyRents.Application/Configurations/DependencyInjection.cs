using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EazzyRents.Application.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            //services.AddScoped<IRequestHandler<LoginQuery, ErrorOr<AuthResult>>, LoginQueryHandler>();
            //services.AddScoped<IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>, RegisterCommandHandler>();

            //services.AddScoped<UserManager<User>>();
            //services.AddIdentityCore<IPasswordHasher<User>>().AddEntityFrameworkStores<AppDbContext>();    

            return services;
        }
    }
}
