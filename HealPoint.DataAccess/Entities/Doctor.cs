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
	public string? EmergencyContactName { get; set; }
	public string? EmergencyContactPhone { get; set; }

	//Professional Details
	public int SpecializationId { get; set; }
	public Specialization? Specialization { get; set; }
	public string? MedicalLicenseNumber { get; set; }
	public DateOnly? LicenseExpiryDate { get; set; }
	public string? Qualifications { get; set; }
	public int? YearOfExperience { get; set; }

	//Education & Training
	public string? Education { get; set; }
	public string? Certifications { get; set; }

	//Department & Position
	public string? Department { get; set; }
	public string? Position { get; set; }

	// Account Link
	public string? ApplicationUserId { get; set; }
	public ApplicationUser? ApplicationUser { get; set; }
}
