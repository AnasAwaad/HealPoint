namespace HealPoint.BusinessLogic.DTOs;
public class DoctorDto
{
	public int Id { get; set; }
	public string UserId { get; set; } = null!;
	public string FirstName { get; set; } = null!;
	public string? LastName { get; set; }
	public string? ProfilePhotoPath { get; set; }
	public string? SpecializationName { get; set; }
	public bool IsDeleted { get; set; }
	public int? NumOfpations { get; set; }
	public int? YearOfExperience { get; set; }
	public string? Email { get; set; }
	public string? PhoneNumber { get; set; }
}
