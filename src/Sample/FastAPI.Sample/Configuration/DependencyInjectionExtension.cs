using FastAPI.Domain;
using FastAPI.Infra.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Application.Boundaries.Services;
using Sample.Application.Services;
using Sample.Domain.Administration.Users;
using Sample.Infra.DataAccess;

namespace FastAPI.Sample.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepository<User>, Repository<User>>();            
            services.AddDbContext<DbContext,FastAPIContext>(
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
