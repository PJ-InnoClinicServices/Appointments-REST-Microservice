using AppointmentREST.BusinessLogic.Interfaces;
using AppointmentREST.DataAccess.Interfaces;
using AppointmentREST.Shared.DTO.AppointmentResult;
using AppointmentREST.Shared.Entites;

namespace AppointmentREST.BusinessLogic.Services
{
    public class AppointmentResultService(IAppointmentResultRepository repository) : IAppointmentResultService
    {
        public async Task<AppointmentResultDto> GetByIdAsync(Guid id)
        {
            var entity = await repository.GetByIdAsync(id);
            return MapToDto(entity);
        }

        public async Task<IEnumerable<AppointmentResultDto>> GetAllAsync()
        {
            var entities = await repository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<IEnumerable<AppointmentResultDto>> GetByDoctorIdAsync(Guid doctorId)
        {
            var entities = await repository.GetByDoctorIdAsync(doctorId);
            return entities.Select(MapToDto);
        }

        public async Task<IEnumerable<AppointmentResultDto>> GetByPatientIdAsync(Guid patientId)
        {
            var entities = await repository.GetByPatientIdAsync(patientId);
            return entities.Select(MapToDto);
        }

        public async Task<IEnumerable<AppointmentResultDto>> GetByAppointmentIdAsync(Guid appointmentId)
        {
            var entities = await repository.GetByAppointmentIdAsync(appointmentId);
            return entities.Select(MapToDto);
        }

        public async Task CreateAsync(CreateAppointmentResultDto dto)
        {
            var entity = new AppointmentResultEntity
            {
                Id = Guid.NewGuid(),
                AppointmentDate = dto.AppointmentDate,
                AppointmentId = dto.AppointmentId,
                Reason = dto.Reason,
                Result = dto.Result,
                Diagnosis = dto.Diagnosis,
                Status = dto.Status,
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                PlaceId = dto.PlaceId
            };

            await repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Guid id, CreateAppointmentResultDto dto)
        {
            var entity = new AppointmentResultEntity
            {
                Id = id,
                AppointmentDate = dto.AppointmentDate,
                AppointmentId = dto.AppointmentId,
                Reason = dto.Reason,
                Result = dto.Result,
                Diagnosis = dto.Diagnosis,
                Status = dto.Status,
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                PlaceId = dto.PlaceId
            };

            await repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        private static AppointmentResultDto MapToDto(AppointmentResultEntity entity)
        {
            return new AppointmentResultDto
            {
                Id = entity.Id,
                AppointmentDate = entity.AppointmentDate,
                AppointmentId = entity.AppointmentId,
                Reason = entity.Reason,
                Result = entity.Result,
                Diagnosis = entity.Diagnosis,
                Status = entity.Status,
                PatientId = entity.PatientId,
                DoctorId = entity.DoctorId,
                PlaceId = entity.PlaceId
            };
        }
    }
}
