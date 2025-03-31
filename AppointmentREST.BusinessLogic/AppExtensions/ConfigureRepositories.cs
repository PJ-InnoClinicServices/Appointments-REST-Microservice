using AppointmentREST.DataAccess.Interfaces;
using AppointmentREST.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentREST.BusinessLogic.AppExtensions;

public static class ConfigureRepositories
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
    }
}