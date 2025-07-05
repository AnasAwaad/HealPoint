namespace HealPoint.BusinessLogic.DTOs;
public class DoctorServiceItemDto
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public string ImageUrl { get; set; } = null!;
	public string? Description { get; set; }

}
