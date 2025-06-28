using HealPoint.DataAccess.Consts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HealPoint.BusinessLogic.DTOs;
public class DoctorFormDto
{
	public int? Id { get; set; }

	[Display(Name = "First Name")]
	[MaxLength(100, ErrorMessage = Errors.MaxLengthExceeded)]
	[RegularExpression(RegexPattern.CharactersOnly_Eng, ErrorMessage = Errors.OnlyEnglishLetters)]
	public string FirstName { get; set; } = null!;

	[Display(Name = "Last Name")]
	[MaxLength(100, ErrorMessage = Errors.MaxLengthExceeded)]
	public string LastName { get; set; }

	[Display(Name = "Date of birth")]
	public DateOnly? DateOfBirth { get; set; }

	[MaxLength(10, ErrorMessage = Errors.MaxLengthExceeded)]
	public string? Gender { get; set; }

	public IFormFile? ImageFile { get; set; }
	public string? ProfilePhotoPath { get; set; }

	// Address
	public string? Address { get; set; }
	public string? City { get; set; }
	public string? State { get; set; }
	public string? Country { get; set; }
	[Display(Name = "Postal Code")]
	public string? PostalCode { get; set; }

	//Contact Information
	[Display(Name = "Phone Number")]
	[MaxLength(11, ErrorMessage = Errors.MaxLengthExceeded)]
	[RegularExpression(RegexPattern.PhoneNumber, ErrorMessage = Errors.PhoneNumberNotAllowed)]
	[Remote("IsAllowedMobileNumber", "Doctors", AdditionalFields = "Id", ErrorMessage = Errors.Dublicated)]
	public string PhoneNumber { get; set; }

	[Display(Name = "Contact Email")]
	[MaxLength(150, ErrorMessage = Errors.MaxLengthExceeded)]
	[EmailAddress]
	[Remote("IsAllowedContactEmail", "Doctors", AdditionalFields = "Id", ErrorMessage = Errors.Dublicated)]
	public string? ContactEmail { get; set; }

	[Display(Name = "Emergency Contact Name")]
	public string? EmergencyContactName { get; set; }

	[Display(Name = "Emergency Contact Number")]
	[MaxLength(11, ErrorMessage = Errors.MaxLengthExceeded)]
	[RegularExpression(RegexPattern.PhoneNumber, ErrorMessage = Errors.PhoneNumberNotAllowed)]
	[Remote("IsAllowedEmergencyContactPhone", "Doctors", AdditionalFields = "Id", ErrorMessage = Errors.Dublicated)]
	public string? EmergencyContactPhone { get; set; }

	//Professional Details
	[Display(Name = "Specialization")]
	public int SpecializationId { get; set; }
	public string? MedicalLicenseNumber { get; set; }
	public DateOnly? LicenseExpiryDate { get; set; }
	public string? Qualifications { get; set; }
	public int YearOfExperience { get; set; }

	//Education & Training
	public string? Education { get; set; }
	public string? Certifications { get; set; }

	//Department & Position
	public int DepartmentId { get; set; }
	public string? Position { get; set; }

	// Account Link
	[Display(Name = "Username"), MaxLength(20, ErrorMessage = Errors.MaxLengthExceeded)]
	[RegularExpression(RegexPattern.Username, ErrorMessage = Errors.AllowUsername)]
	[Remote("IsAllowedUserName", "Doctors", AdditionalFields = "Id", ErrorMessage = Errors.Dublicated)]
	public string UserName { get; set; } = null!;

	[MaxLength(150, ErrorMessage = Errors.MaxLengthExceeded)]
	[EmailAddress]
	[Remote("IsAllowedEmail", "Doctors", AdditionalFields = "Id", ErrorMessage = Errors.Dublicated)]
	public string Email { get; set; } = null!;

	[StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = Errors.MinMaxLength), DataType(DataType.Password)]
	[RegularExpression(RegexPattern.Password, ErrorMessage = Errors.WeakPassword)]
	public string Password { get; set; } = null!;


	public IEnumerable<SelectListItem>? SpecializationSelectList { get; set; } = new List<SelectListItem>();
	public IEnumerable<SelectListItem>? DepartmentSelectList { get; set; } = new List<SelectListItem>();

}
