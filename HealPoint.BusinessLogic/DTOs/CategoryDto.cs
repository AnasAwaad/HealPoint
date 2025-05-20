namespace HealPoint.BusinessLogic.DTOs;
public class CategoryDto
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public string? ParentCategoryName { get; set; }
	public DateTime CreatedOn { get; set; }
	public DateTime? LastUpdatedOn { get; set; }
	public bool IsFeatured { get; set; }
	public bool Status { get; set; }
}
