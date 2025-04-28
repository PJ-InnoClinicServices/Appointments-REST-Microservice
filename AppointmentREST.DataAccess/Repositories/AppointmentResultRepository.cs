using AppointmentREST.DataAccess.Interfaces;
using AppointmentREST.Shared.Entites;
using Microsoft.EntityFrameworkCore;

namespace AppointmentREST.DataAccess.Repositories
{
    public class AppointmentResultRepository(ApplicationDbContext context) : IAppointmentResultRepository
    {
        public async Task<AppointmentResultEntity> GetByIdAsync(Guid id)
        {
            return await context.AppointmentResults.FindAsync(id);
        }

        public async Task<IEnumerable<AppointmentResultEntity>> GetAllAsync()
        {
            return await context.AppointmentResults.ToListAsync();
        }

        public async Task<IEnumerable<AppointmentResultEntity>> GetByDoctorIdAsync(Guid doctorId)
        {
            return await context.AppointmentResults.Where(x => x.DoctorId == doctorId).ToListAsync();
        }

        public async Task<IEnumerable<AppointmentResultEntity>> GetByPatientIdAsync(Guid patientId)
        {
            return await context.AppointmentResults.Where(x => x.PatientId == patientId).ToListAsync();
        }

        public async Task<IEnumerable<AppointmentResultEntity>> GetByAppointmentIdAsync(Guid appointmentId)
        {
            return await context.AppointmentResults.Where(x => x.AppointmentId == appointmentId).ToListAsync();
        }

        public async Task AddAsync(AppointmentResultEntity appointmentResult)
        {
            context.AppointmentResults.Add(appointmentResult);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AppointmentResultEntity appointmentResult)
        {
            context.AppointmentResults.Update(appointmentResult);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await context.AppointmentResults.FindAsync(id);
            if (entity != null)
            {
                context.AppointmentResults.Remove(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
