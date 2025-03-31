using AppointmentREST.Shared.DTO;
using AppointmentREST.Shared.Entites;
using Microsoft.Extensions.DependencyInjection;
using Nelibur.ObjectMapper;

namespace AppointmentREST.BusinessLogic.AppExtensions;

public abstract class MapperRegistration
{
    public static void AddTinyMapper(IServiceCollection services)
    {
        TinyMapper.Bind<CreateAppointmentDto, AppointmentEntity>();
        TinyMapper.Bind<UpdateAppointmentDto, AppointmentEntity>();
    }
}