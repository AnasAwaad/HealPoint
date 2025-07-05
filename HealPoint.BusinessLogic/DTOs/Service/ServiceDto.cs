namespace HealPoint.BusinessLogic.DTOs;
public class ServiceDto
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public string ImageUrl { get; set; } = null!;
	public string? Description { get; set; }
	public DateTime CreatedOn { get; set; }
	public DateTime? LastUpdatedOn { get; set; }
	public bool IsDeleted { get; set; }
}
