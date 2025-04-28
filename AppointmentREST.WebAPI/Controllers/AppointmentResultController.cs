using AppointmentREST.BusinessLogic.Interfaces;
using AppointmentREST.Shared.DTO.AppointmentResult;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentResultController(IAppointmentResultService service) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetByDoctorId(Guid doctorId)
        {
            var result = await service.GetByDoctorIdAsync(doctorId);
            return Ok(result);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetByPatientId(Guid patientId)
        {
            var result = await service.GetByPatientIdAsync(patientId);
            return Ok(result);
        }

        [HttpGet("appointment/{appointmentId}")]
        public async Task<IActionResult> GetByAppointmentId(Guid appointmentId)
        {
            var result = await service.GetByAppointmentIdAsync(appointmentId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentResultDto dto)
        {
            await service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateAppointmentResultDto dto)
        {
            await service.UpdateAsync(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.DeleteAsync(id);
            return Ok();
        }
    }
}
