using AppointmentREST.Shared.Entites;

namespace AppointmentREST.DataAccess.Interfaces;

public interface IAppointmentResultRepository
{
    Task<AppointmentResultEntity> GetByIdAsync(Guid id);
    Task<IEnumerable<AppointmentResultEntity>> GetAllAsync();
    Task<IEnumerable<AppointmentResultEntity>> GetByDoctorIdAsync(Guid doctorId);
    Task<IEnumerable<AppointmentResultEntity>> GetByPatientIdAsync(Guid patientId);
    Task<IEnumerable<AppointmentResultEntity>> GetByAppointmentIdAsync(Guid appointmentId);
    Task AddAsync(AppointmentResultEntity appointmentResult);
    Task UpdateAsync(AppointmentResultEntity appointmentResult);
    Task DeleteAsync(Guid id);
}