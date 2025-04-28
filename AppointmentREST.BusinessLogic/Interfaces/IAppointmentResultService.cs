using AppointmentREST.Shared.DTO.AppointmentResult;

namespace AppointmentREST.BusinessLogic.Interfaces;

public interface IAppointmentResultService
{
    Task<AppointmentResultDto> GetByIdAsync(Guid id);
    Task<IEnumerable<AppointmentResultDto>> GetAllAsync();
    Task<IEnumerable<AppointmentResultDto>> GetByDoctorIdAsync(Guid doctorId);
    Task<IEnumerable<AppointmentResultDto>> GetByPatientIdAsync(Guid patientId);
    Task<IEnumerable<AppointmentResultDto>> GetByAppointmentIdAsync(Guid appointmentId);
    Task CreateAsync(CreateAppointmentResultDto dto);
    Task UpdateAsync(Guid id, CreateAppointmentResultDto dto);
    Task DeleteAsync(Guid id);
}