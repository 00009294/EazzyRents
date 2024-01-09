using EazzyRents.Application.Authentication.Commands;
using EazzyRents.Application.Authentication.Common;
using EazzyRents.Application.Authentication.Queries;
using EazzyRents.Application.Common.Interfaces.Authentication;
using EazzyRents.Core.Enums;
using EazzyRents.Core.Models;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
