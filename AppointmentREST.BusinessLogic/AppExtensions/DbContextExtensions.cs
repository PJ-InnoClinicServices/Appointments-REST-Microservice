using AppointmentREST.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentREST.BusinessLogic.AppExtensions;

public static class DbContextExtensions
{
    public static void AddDbContextService(this IServiceCollection services, IConfiguration configuration)
    {
        
        var dbPassword = Environment.GetEnvironmentVariable("NEON_DB_PASSWORD");
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            .Replace("${NEON_DB_PASSWORD}", dbPassword);
        
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString,
                npgsqlOptions => { npgsqlOptions.MigrationsHistoryTable("__EFMigrationsHistory_Appointments"); }));
    }
}