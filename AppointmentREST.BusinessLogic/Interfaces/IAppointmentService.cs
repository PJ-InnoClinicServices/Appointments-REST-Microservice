using AppointmentREST.Shared.DTO;
using AppointmentREST.Shared.Entites;

namespace AppointmentREST.BusinessLogic.Interfaces;

public interface IAppointmentService
{
    Task<IEnumerable<AppointmentDto>> GetAppointmentsByPatientId(Guid patientId);
    Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorId(Guid doctorId);
    Task<IEnumerable<AppointmentDto>> GetAppointmentsByPlaceId(Guid placeId);
    Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorPlaceDate(Guid doctorId, Guid placeId, DateTime appointmentDate);
    Task<AppointmentDto> GetById(Guid id);
    Task CreateAppointment(CreateAppointmentDto createAppointmentDto);
    Task UpdateAppointment(Guid id, UpdateAppointmentDto updateAppointmentDto);
    Task DeleteAppointment(Guid id);
    Task<IEnumerable<AppointmentEntity>> GetAllAppointments();
}