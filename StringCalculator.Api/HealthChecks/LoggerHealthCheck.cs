using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace StringCalculator.Api.HealthChecks
{
    public class LoggerHealthCheck: IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var healthCheckResultHealthy = Directory.Exists("../Logs");
            if (healthCheckResultHealthy)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy("Logs have been updated succesfully"));
            }

            return Task.FromResult(
                new HealthCheckResult(context.Registration.FailureStatus,
                    "Logs have not been updated succesfully"));
        }
    }
}
