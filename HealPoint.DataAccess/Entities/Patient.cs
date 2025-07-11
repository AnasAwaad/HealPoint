namespace HealPoint.DataAccess.Entities;
public class Patient : BaseEntity
{
	public string ApplicationUserId { get; set; } = null!;
	public ApplicationUser User { get; set; } = null!;
	public DateTime DateOfBirth { get; set; }
	public string? Gender { get; set; }
	public string? Address { get; set; }

	public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
