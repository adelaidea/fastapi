using FastAPI.Application.Abstraction.Service.Administration;
using FastAPI.Application.Services;
using FastAPI.Domain.Abstractions.Repositories;
using FastAPI.Domain.Abstractions.Services;
using FastAPI.Domain.Entities;
using FastAPI.Domain.Services;
using FastAPI.Infra.DataAccess;
using FastAPI.Infra.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FastAPI.Sample.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepository<User>, Repository<User>>();            
            services.AddDbContext<FastAPIContext>(
                 options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }


        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserApplicationService, UserApplicationService>();
            return services;
        }

        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IUserDomainService, UserDomainService>();
            return services;
        }
    }
}
