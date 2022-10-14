using app.Api.Extensions.HealthCheckFilter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace app.Api.Configuration
{
    public static class HealthCheckConfig
    {
        public static IServiceCollection ConfigureHealthCheck(this IServiceCollection services, IConfiguration config)
        {
            string connectionString = config.GetConnectionString("DefaultConnection");
            services.AddHealthChecks()
                    .AddSqlServer(connectionString, name: "BancoSQL")
                    .CheckSqlTables(connectionString);

            services.AddHealthChecksUI()
                    .AddSqlServerStorage(config.GetConnectionString("DefaultConnection"));
            return services;
        }

        private static IHealthChecksBuilder CheckSqlTables(this IHealthChecksBuilder heatlhCheck, string connectionString)
        {
            heatlhCheck.AddCheck("[dbo].[NaturalPerson]", new SqlServerHealthCheck(connectionString, "select count(Id) from NaturalPerson"));
            heatlhCheck.AddCheck("[dbo].[LegalPerson]", new SqlServerHealthCheck(connectionString, "select count(Id) from LegalPerson"));
            return heatlhCheck;
        }
    }
}
