
using HealPoint.DataAccess.Enums;

namespace HealPoint.DataAccess.Entities;
public class Doctor : BaseEntity
{
	// Personal Information
	public DateOnly? DateOfBirth { get; set; }
	public string? Gender { get; set; }
	public string? ProfilePhotoPath { get; set; }

	// Address
	public string? Address { get; set; }
	public string? City { get; set; }
	public string? State { get; set; }
	public string? Country { get; set; }
	public string? PostalCode { get; set; }

	//Contact Information
	public string? ContactEmail { get; set; } // From Doctor Entity
	public string? EmergencyContactName { get; set; }
	public string? EmergencyContactPhone { get; set; }

	//Professional Details
	public int SpecializationId { get; set; }
	public Specialization? Specialization { get; set; }
	public string? MedicalLicenseNumber { get; set; }
	public DateOnly? LicenseExpiryDate { get; set; }
	public string? Qualifications { get; set; }
	public int? YearOfExperience { get; set; }
	public DoctorOperationMode OperationMode { get; set; }
	//Education & Training
	public string? Education { get; set; }
	public string? Certifications { get; set; }

	//Department & Position
	public int DepartmentId { get; set; }
	public Department? Department { get; set; }
	public string? Position { get; set; }

	// Account Link
	public string Email { get; set; } // Used for login
	public string? ApplicationUserId { get; set; }
	public ApplicationUser? ApplicationUser { get; set; }

	public ICollection<DoctorSchedule> Schedules { get; set; } = new List<DoctorSchedule>();
	public ICollection<DoctorService> DoctorServices { get; set; } = new List<DoctorService>();
}
