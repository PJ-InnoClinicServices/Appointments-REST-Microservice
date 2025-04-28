using AppointmentREST.BusinessLogic.Interfaces;
using AppointmentREST.DataAccess.Interfaces;
using AppointmentREST.Shared.DTO;
using AppointmentREST.Shared.DTO.Appointment;
using AppointmentREST.Shared.Entites;
using Nelibur.ObjectMapper;

namespace AppointmentREST.BusinessLogic.Services;

public class AppointmentService(IAppointmentRepository appointmentRepository) : IAppointmentService
{
    public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByPatientId(Guid patientId)
    {
        var appointments = await appointmentRepository.GetAppointmentsByPatientId(patientId);
        return appointments.Select(TinyMapper.Map<AppointmentDto>).ToList();
    }

    public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorId(Guid doctorId)
    {
        var appointments = await appointmentRepository.GetAppointmentsByDoctorId(doctorId);
        return appointments.Select(TinyMapper.Map<AppointmentDto>).ToList();
    }

    public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByPlaceId(Guid placeId)
    {
        var appointments = await appointmentRepository.GetAppointmentsByPlaceId(placeId);
        return appointments.Select(TinyMapper.Map<AppointmentDto>).ToList();
    }

    public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorPlaceDate(Guid doctorId, Guid placeId, DateTime appointmentDate)
    {
        var appointments = await appointmentRepository.GetAppointmentsByDoctorPlaceDate(doctorId, placeId, appointmentDate);
        return appointments.Select(TinyMapper.Map<AppointmentDto>).ToList();
    }
    
    public async Task<AppointmentDto> GetById(Guid id)
    {
        var appointment = await appointmentRepository.GetById(id);
        return appointment != null ? TinyMapper.Map<AppointmentDto>(appointment) : null;
    }

    public async Task CreateAppointment(CreateAppointmentDto createAppointmentDto)
    {
        var appointment = TinyMapper.Map<AppointmentEntity>(createAppointmentDto);
        appointment.Id = Guid.NewGuid();
        await appointmentRepository.Create(appointment);
    }

    public async Task UpdateAppointment(Guid id, UpdateAppointmentDto updateAppointmentDto)
    {
        var appointment = await appointmentRepository.GetById(id);
        if (appointment != null)
        {
            TinyMapper.Map(updateAppointmentDto, appointment); 
            await appointmentRepository.Update(appointment);
        }
    }

    public async Task DeleteAppointment(Guid id)
    {
        await appointmentRepository.Delete(id);
    }
    
    public async Task<IEnumerable<AppointmentEntity>> GetAllAppointments()
    {
        return await appointmentRepository.GetAllAsync();
    }
    
}
