namespace HealPoint.DataAccess.Contracts;
public interface IDepartmentRepository : IRepository<Department>
{
	IEnumerable<Department> GetActiveDepartments();
	bool IsDepartmentNameAllowed(string departmentName, int? excludeDepartmentId = null);
}
