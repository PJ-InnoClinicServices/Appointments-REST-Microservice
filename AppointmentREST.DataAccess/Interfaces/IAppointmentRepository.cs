using AppointmentREST.Shared.DTO;
using AppointmentREST.Shared.Entites;

namespace AppointmentREST.DataAccess.Interfaces;

public interface IAppointmentRepository
{
    Task<IEnumerable<AppointmentEntity>> GetAllAsync();
    Task<IEnumerable<AppointmentEntity>> GetAppointmentsByPatientId(Guid patientId);
    Task<IEnumerable<AppointmentEntity>> GetAppointmentsByDoctorId(Guid doctorId);
    Task<IEnumerable<AppointmentEntity>> GetAppointmentsByPlaceId(Guid placeId);
    Task<IEnumerable<AppointmentEntity>> GetAppointmentsByDoctorPlaceDate(Guid doctorId, Guid placeId, DateTime appointmentDate);
    Task<AppointmentEntity> GetById(Guid id);
    Task Create(AppointmentEntity appointment);
    Task Update(AppointmentEntity appointment);
    Task Delete(Guid id);
}