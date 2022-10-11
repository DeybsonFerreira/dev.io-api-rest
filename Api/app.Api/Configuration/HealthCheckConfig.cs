using Microsoft.Extensions.DependencyInjection;

namespace app.Api.Configuration
{
    public static class HealthCheckConfig
    {
        public static IServiceCollection ConfigureHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks();
            return services;
        }
    }
}
