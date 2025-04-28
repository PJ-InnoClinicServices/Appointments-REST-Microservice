namespace AppointmentREST.Shared.DTO;

public record AppointmentWithDoctorPlaceDateDto
{
    public Guid DoctorId { get; set; }
    public Guid PlaceId { get; set; }
    public DateTime AppointmentDate { get; set; }
}