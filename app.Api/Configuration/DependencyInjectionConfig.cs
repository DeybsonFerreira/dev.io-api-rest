using app.Business.Interfaces;
using app.Business.Notification;
using app.Business.Services;
using app.Data.Context;
using app.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace app.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependency(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ApiDbContext>();
            services.AddDbContext<ApiDbContext>(option => { option.UseSqlServer(config.GetConnectionString("DefaultConnection")); });
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<INotify, Notify>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}