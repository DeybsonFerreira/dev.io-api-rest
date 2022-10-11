using app.Business.Interfaces.CreateServices;
using app.Business.Interfaces.DeleteServices;
using app.Business.Interfaces.ReadServices;
using app.Business.Interfaces.Repositories;
using app.Business.Interfaces.Services;
using app.Business.Interfaces.UpdateServices;
using app.Business.Notification;
using app.Business.Services;
using app.Business.Services.CreateServices;
using app.Business.Services.DeleteServices;
using app.Business.Services.ReadServices;
using app.Business.Services.UpdateServices;
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
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddScoped<ApiDbContext>();
            services.AddDbContext<ApiDbContext>(option => { option.UseSqlServer(config.GetConnectionString("DefaultConnection")); });
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILegalPersonRepository, LegalPersonRepository>();

            services.AddScoped<INotify, Notify>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();

            services.NaturalPersonDependences();
            return services;
        }

        public static IServiceCollection NaturalPersonDependences(this IServiceCollection services)
        {
            services.AddScoped<INaturalPersonRepository, NaturalPersonRepository>();
            services.AddScoped<INaturalPersonService, NaturalPersonService>();
            services.AddScoped<ICreateNaturalPerson, CreateNaturalPerson>();
            services.AddScoped<IReadNaturalPerson, ReadNaturalPerson>();
            services.AddScoped<IUpdateNaturalPerson, UpdateNaturalPerson>();
            services.AddScoped<IDeleteNaturalPerson, DeleteNaturalPerson>();
            return services;
        }
    }
}