namespace HealPoint.DataAccess.Contracts;
public interface IDepartmentRepository : IRepository<Department>
{
	bool IsDepartmentNameAllowed(string departmentName, int? excludeDepartmentId = null);
	IEnumerable<Department> GetActiveDepartments();
}
