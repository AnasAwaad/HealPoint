namespace HealPoint.DataAccess.Entities;
public class Service : BaseEntity
{
	public string Name { get; set; } = null!;
	public string? Description { get; set; }

	public ICollection<DoctorService> DoctorServices { get; set; }
}
