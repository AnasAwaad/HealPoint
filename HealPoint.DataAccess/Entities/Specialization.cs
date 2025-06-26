namespace HealPoint.DataAccess.Entities;
public class Specialization : BaseEntity
{
	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
	public int CategoryId { get; set; }
	public Category? Category { get; set; }
	public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
