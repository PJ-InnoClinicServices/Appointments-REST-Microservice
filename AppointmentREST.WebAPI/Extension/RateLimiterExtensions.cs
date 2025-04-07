using System.Threading.RateLimiting;

namespace AppointmentREST.Extension;

public static class RateLimiterExtensions
{
    public static void AddCustomRateLimiter(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRateLimiter(options =>
        {
            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
                    factory: partition => new FixedWindowRateLimiterOptions
                    {
                        AutoReplenishment = true,
                        PermitLimit = 100, 
                        QueueLimit = 0,  
                        Window = TimeSpan.FromMinutes(1) 
                    }));
        });
    }
}