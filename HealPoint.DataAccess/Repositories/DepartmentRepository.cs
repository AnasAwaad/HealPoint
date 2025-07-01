using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Data;

namespace HealPoint.DataAccess.Repositories;
internal class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
	public DepartmentRepository(ApplicationDbContext context) : base(context)
	{
	}

	// Perform soft delete: Set IsDeleted to true instead of removing
	public override void Delete(int id)
	{
		var department = _context.Departments.Find(id);
		if (department != null)
		{

			department.IsDeleted = true;
			department.LastUpdatedOn = DateTime.Now;
		}
	}

	public bool IsDepartmentNameAllowed(string departmentName, int? excludeDepartmentId = null)
	{
		var department = _context.Departments.SingleOrDefault(c => c.Name == departmentName && !c.IsDeleted);

		return department is null || department.Id.Equals(excludeDepartmentId);
	}

	public IEnumerable<Department> GetActiveDepartments()
	{
		return _context.Departments
			.Where(d => !d.IsDeleted)
			.AsEnumerable();
	}
}
