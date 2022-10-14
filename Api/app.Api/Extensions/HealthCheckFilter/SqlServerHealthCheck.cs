using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace app.Api.Extensions.HealthCheckFilter
{
    public class SqlServerHealthCheck : IHealthCheck
    {
        readonly string _connection;
        readonly string _command;

        public SqlServerHealthCheck(string connection, string command)
        {
            _connection = connection;
            _command = command;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                using var connection = new SqlConnection(_connection);
                await connection.OpenAsync(cancellationToken);

                var command = connection.CreateCommand();
                command.CommandText = _command;

                await command.ExecuteScalarAsync(cancellationToken);
                return HealthCheckResult.Healthy();
            }
            catch (Exception)
            {
                return HealthCheckResult.Unhealthy();
            }
        }

    }
}
