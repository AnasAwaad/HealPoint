using Microsoft.AspNetCore.Identity;

namespace HealPoint.DataAccess.Entities;
public class ApplicationUser : IdentityUser
{
	public string FirstName { get; set; } = null!;
	public string? LastName { get; set; }
	public DateTime CreatedOn { get; set; }
	public string? CreatedById { get; set; }
	public DateTime? LastUpdatedOn { get; set; }
	public string? LastUpdatedById { get; set; }
	public bool IsDeleted { get; set; }

	public Doctor Doctor { get; set; }
}
