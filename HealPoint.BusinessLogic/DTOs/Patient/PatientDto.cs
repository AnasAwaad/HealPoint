namespace HealPoint.BusinessLogic.DTOs;
public class PatientDto
{
	public int Id { get; set; }
	public string UserId { get; set; } = null!;
	public string FirstName { get; set; } = null!;
	public string? LastName { get; set; }
	public string? Email { get; set; }
	public string? PhoneNumber { get; set; }
	public string? ProfilePhotoPath { get; set; }
	public bool IsDeleted { get; set; }
}
