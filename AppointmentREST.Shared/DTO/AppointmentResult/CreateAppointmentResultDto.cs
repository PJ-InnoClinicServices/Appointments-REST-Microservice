using AppointmentREST.Shared.Enum;

namespace AppointmentREST.Shared.DTO.AppointmentResult;

public record CreateAppointmentResultDto
{
    public DateTime AppointmentDate { get; set; }
    public Guid AppointmentId { get; set; }
    public string Reason { get; set; }
    public string Result { get; set; }
    public string Diagnosis { get; set; }
    public AppointmentStatus Status { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid PlaceId { get; set; }
}