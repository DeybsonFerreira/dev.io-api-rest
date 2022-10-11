using app.Api.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace app.Api.Configuration
{
    public static class IdentityConfig
    {
        //add-migration Identity -Context ApplicationDbContext
        public static IServiceCollection ConfigureIdentity(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                //.AddErrorDescriber<IdentityMensagensPortugues>()
                .AddDefaultTokenProviders(); //exemplo : enviar token por email

            // JWT
            return services;
        }

    }
}
