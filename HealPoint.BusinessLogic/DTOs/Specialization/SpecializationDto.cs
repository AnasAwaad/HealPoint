namespace HealPoint.BusinessLogic.DTOs;
public class SpecializationDto
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
	public string DepartmentName { get; set; } = null!;
	public bool IsDeleted { get; set; }
}
