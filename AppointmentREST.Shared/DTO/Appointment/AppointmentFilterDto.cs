namespace AppointmentREST.Shared.DTO.Appointment;

public record AppointmentFilterDto
{
    public Guid? PatientId { get; set; }
    public Guid? DoctorId { get; set; }
    public Guid? PlaceId { get; set; }
    public DateTime? AppointmentDate { get; set; }
}
