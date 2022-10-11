using app.Business.Interfaces.Repositories;
using app.Business.Interfaces.Services;
using app.Business.Notification;
using app.Business.Services;
using app.Data.Context;
using app.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using static app.Api.Configuration.SwaggerConfig;

namespace app.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependency(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddScoped<ApiDbContext>();
            services.AddDbContext<ApiDbContext>(option => { option.UseSqlServer(config.GetConnectionString("DefaultConnection")); });
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILegalPersonRepository, LegalPersonRepository>();
            services.AddScoped<INaturalPersonRepository, NaturalPersonRepository>();

            services.AddScoped<INotify, Notify>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}