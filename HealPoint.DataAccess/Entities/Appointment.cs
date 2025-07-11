using HealPoint.DataAccess.Enums;

namespace HealPoint.DataAccess.Entities;
public class Appointment : BaseEntity
{

	// Appointment info
	public DateTime AppointmentDate { get; set; }
	public TimeSpan AppointmentTime { get; set; }
	public AppointmentStatus Status { get; set; }
	public int Charge { get; set; }

	// Patient info
	public int PatientId { get; set; }
	public Patient Patient { get; set; }
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string Gender { get; set; } = null!;
	public string Phone { get; set; } = null!;
	public string Email { get; set; } = null!;
	public DateTime DateOfBirth { get; set; }
	public string Address { get; set; } = null!;
	public string AppointmentReason { get; set; } = null!;
	public string? MedicalDocument { get; set; }
	public string Ocupation { get; set; } = null!;

	// Doctor info
	public int DoctorId { get; set; }
	public Doctor Doctor { get; set; }
}
