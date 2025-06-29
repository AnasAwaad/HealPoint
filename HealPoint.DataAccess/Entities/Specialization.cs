using HealPoint.DataAccess.Common;

namespace HealPoint.DataAccess.Entities;
public class Specialization : BaseEntity
{
	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
	public int DepartmentId { get; set; }
	public Department? Department { get; set; }
	public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
