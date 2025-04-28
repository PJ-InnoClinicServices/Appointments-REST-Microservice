using AppointmentREST.BusinessLogic.Interfaces;
using AppointmentREST.Shared.DTO;
using AppointmentREST.Shared.DTO.Appointment;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentREST.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentsController(IAppointmentService appointmentService) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var appointments = await appointmentService.GetAllAppointments();
            return Ok(appointments);
        }
        
        [HttpGet("filter")]
        public async Task<IActionResult> GetFiltered(
            [FromQuery] Guid? patientId, 
            [FromQuery] Guid? doctorId, 
            [FromQuery] Guid? placeId, 
            [FromQuery] DateTime? appointmentDate)
        {
            if (patientId.HasValue)
            {
                var appointments = await appointmentService.GetAppointmentsByPatientId(patientId.Value);
                return Ok(appointments);
            }

            if (doctorId.HasValue)
            {
                var appointments = await appointmentService.GetAppointmentsByDoctorId(doctorId.Value);
                return Ok(appointments);
            }

            if (placeId.HasValue)
            {
                var appointments = await appointmentService.GetAppointmentsByPlaceId(placeId.Value);
                return Ok(appointments);
            }

            if (appointmentDate.HasValue && doctorId.HasValue && placeId.HasValue)
            {
                var appointments = await appointmentService.GetAppointmentsByDoctorPlaceDate(doctorId.Value, placeId.Value, appointmentDate.Value);
                return Ok(appointments);
            }

            return BadRequest("Please provide valid filter parameters.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var appointment = await appointmentService.GetById(id);
            if (appointment == null)
                return NotFound();

            return Ok(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentDto createAppointmentDto)
        {
            await appointmentService.CreateAppointment(createAppointmentDto);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAppointmentDto updateAppointmentDto)
        {
            await appointmentService.UpdateAppointment(id, updateAppointmentDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await appointmentService.DeleteAppointment(id);
            return NoContent();
        }
    }
}
