namespace HealPoint.BusinessLogic.DTOs;
public class DepartmentDto
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
	public DateTime CreatedOn { get; set; }
	public DateTime? LastUpdatedOn { get; set; }
	public bool IsFeatured { get; set; }
	public bool IsDeleted { get; set; }
}
