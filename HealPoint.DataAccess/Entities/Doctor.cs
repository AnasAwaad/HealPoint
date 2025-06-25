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
	public string? PostalCode { get; set; }
	public string? Country { get; set; }
	public int? Experience { get; set; }


	public int SpecializationId { get; set; }
	public Specialization? Specialization { get; set; }

	public string ApplicationUserId { get; set; }
	public ApplicationUser? ApplicationUser { get; set; }
}
