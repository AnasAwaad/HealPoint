using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealPoint.BusinessLogic.DTOs;
public class CreateDoctorDto
{

	public string FirstName { get; set; } = null!;
	public string? LastName { get; set; }

	public DateOnly? DateOfBirth { get; set; }
	public string? Gender { get; set; }
	public IFormFile? ImageFile { get; set; }

	// Address
	public string? Address { get; set; }
	public string? City { get; set; }
	public string? State { get; set; }
	public string? Country { get; set; }
	public string? PostalCode { get; set; }

	//Contact Information
	public string? PhoneNumber { get; set; }
	public string? ContactEmail { get; set; }
	public string? EmergencyContactName { get; set; }
	public string? EmergencyContactPhone { get; set; }

	//Professional Details
	public int SpecializationId { get; set; }
	public IEnumerable<SelectListItem>? SpecializationSelectList { get; set; } = new List<SelectListItem>();
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
	public string? UserName { get; set; }
	public string? Email { get; set; }
	public string? Password { get; set; }
	public string? RepeatPassword { get; set; }
}
