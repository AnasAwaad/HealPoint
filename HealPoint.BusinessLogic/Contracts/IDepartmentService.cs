namespace HealPoint.BusinessLogic.Contracts;
public interface IDepartmentService
{
	IEnumerable<DepartmentDto> GetAllDepartments();
	DepartmentFormDto? GetDepartmentById(int id);
	IEnumerable<DepartmentDto> GetDepartmentsLookup();
	DepartmentDto CreateDepartment(DepartmentFormDto department);
	DepartmentDto? UpdateDepartment(DepartmentFormDto department);
	string? UpdateFeaturedStatus(int id);
	(bool? isDeleted, string? lastUpdatedOn) UpdateDepartmentStatus(int id);
	bool DeleteDepartment(int id);
	bool IsDepartmentAllowed(DepartmentFormDto department);
}
