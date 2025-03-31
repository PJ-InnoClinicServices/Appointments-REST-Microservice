using AppointmentREST.BusinessLogic.Interfaces;
using AppointmentREST.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentREST.BusinessLogic.AppExtensions;

public static class ConfigureServices
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAppointmentService, AppointmentService>();
    }
}