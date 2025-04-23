using AppointmentREST.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AppointmentREST.Extension;

public static class DbContextRegistration
{
    public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    { 
    }
}