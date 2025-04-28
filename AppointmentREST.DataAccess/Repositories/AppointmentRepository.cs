using AppointmentREST.DataAccess.Interfaces;
using AppointmentREST.Shared.DTO;
using AppointmentREST.Shared.DTO.Appointment;
using AppointmentREST.Shared.Entites;
using Microsoft.EntityFrameworkCore;

namespace AppointmentREST.DataAccess.Repositories;

  public class AppointmentRepository(ApplicationDbContext context) : IAppointmentRepository
  {
      public async Task<IEnumerable<AppointmentEntity>> GetAppointmentsByPatientId(Guid patientId)
        {
            return await context.Appointments.Where(a => a.PatientId == patientId).ToListAsync();
        }

        public async Task<IEnumerable<AppointmentEntity>> GetAppointmentsByDoctorId(Guid doctorId)
        {
            return await context.Appointments.Where(a => a.DoctorId == doctorId).ToListAsync();
        }

        public async Task<IEnumerable<AppointmentEntity>> GetAppointmentsByPlaceId(Guid placeId)
        {
            return await context.Appointments.Where(a => a.PlaceId == placeId).ToListAsync();
        }

        public async Task<IEnumerable<AppointmentEntity>> GetAppointmentsByDoctorPlaceDate(Guid doctorId, Guid placeId, DateTime appointmentDate)
        {
            return await context.Appointments
                .Where(a => a.DoctorId == doctorId && a.PlaceId == placeId && a.AppointmentDate.Date == appointmentDate.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentEntity>> GetAppointmentsByFilter(AppointmentFilterDto filter)
        {
            var query = context.Appointments.AsQueryable();

            if (filter.PatientId.HasValue)
                query = query.Where(a => a.PatientId == filter.PatientId);

            if (filter.DoctorId.HasValue)
                query = query.Where(a => a.DoctorId == filter.DoctorId);

            if (filter.PlaceId.HasValue)
                query = query.Where(a => a.PlaceId == filter.PlaceId);

            if (filter.AppointmentDate.HasValue)
                query = query.Where(a => a.AppointmentDate.Date == filter.AppointmentDate.Value.Date);

            return await query.ToListAsync();
        }

        public async Task<AppointmentEntity> GetById(Guid id)
        {
            return await context.Appointments.FindAsync(id);
        }

        public async Task Create(AppointmentEntity appointment)
        {
            context.Appointments.Add(appointment);
            await context.SaveChangesAsync();
        }

        public async Task Update(AppointmentEntity appointment)
        {
            context.Appointments.Update(appointment);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var appointment = await context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                context.Appointments.Remove(appointment);
                await context.SaveChangesAsync();
            }
        }
        
        public async Task<IEnumerable<AppointmentEntity>> GetAllAsync()
        {
            return await context.Appointments.ToListAsync();
        }
        
    }