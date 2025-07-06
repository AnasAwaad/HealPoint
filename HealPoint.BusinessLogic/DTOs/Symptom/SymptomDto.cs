namespace HealPoint.BusinessLogic.DTOs;
public class SymptomDto
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public DateTime CreatedOn { get; set; }
	public DateTime? LastUpdatedOn { get; set; }
	public bool IsDeleted { get; set; }
}
