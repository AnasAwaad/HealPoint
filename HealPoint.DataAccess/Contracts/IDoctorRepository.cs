namespace HealPoint.DataAccess.Contracts;
public interface IDoctorRepository : IRepository<Doctor>
{
	IEnumerable<Doctor> GetAllWithDetails();
}
