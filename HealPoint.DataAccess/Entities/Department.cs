namespace HealPoint.DataAccess.Entities;
public class Department : BaseEntity
{
	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
	public string? ImagePath { get; set; }
	public bool IsFeatured { get; set; }
}
