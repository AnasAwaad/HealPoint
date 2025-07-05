using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Services;
public class DepartmentService : IDepartmentService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public IEnumerable<DepartmentDto> GetAllDepartments()
	{
		var departments = _unitOfWork.Departments.GetAll();
		return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
	}

	public DepartmentFormDto? GetDepartmentById(int id)
	{
		var department = _unitOfWork.Departments.FindById(id);

		return _mapper.Map<DepartmentFormDto>(department);
	}

	public DepartmentDto? UpdateDepartment(DepartmentFormDto departmentDto)
	{
		var existingDepartment = _unitOfWork.Departments.FindById(departmentDto.Id);

		if (existingDepartment == null)
		{
			return null;
		}

		_mapper.Map(departmentDto, existingDepartment);
		existingDepartment.LastUpdatedOn = DateTime.Now;

		_unitOfWork.SaveChanges();

		return _mapper.Map<DepartmentDto>(existingDepartment);
	}

	public DepartmentDto CreateDepartment(DepartmentFormDto departmentDto)
	{
		var department = _mapper.Map<Department>(departmentDto);
		_unitOfWork.Departments.Insert(department);
		_unitOfWork.SaveChanges();

		return _mapper.Map<DepartmentDto>(department);
	}

	public string? UpdateFeaturedStatus(int id)
	{
		var existingDepartment = _unitOfWork.Departments.FindById(id);

		if (existingDepartment == null)
			return null;

		existingDepartment.IsFeatured = !existingDepartment.IsFeatured;
		existingDepartment.LastUpdatedOn = DateTime.Now;

		_unitOfWork.SaveChanges();

		return existingDepartment.LastUpdatedOn.Value.ToString("dddd, dd MMMM yyyy h:mm tt");
	}

	public (bool? isDeleted, string? lastUpdatedOn) UpdateDepartmentStatus(int id)
	{
		var existingDepartment = _unitOfWork.Departments.FindById(id);

		if (existingDepartment == null)
			return (null, null);

		existingDepartment.IsDeleted = !existingDepartment.IsDeleted;
		existingDepartment.LastUpdatedOn = DateTime.Now;

		_unitOfWork.SaveChanges();

		return (existingDepartment.IsDeleted, DateTime.Now.ToString("dddd, dd MMMM yyyy h:mm tt"));
	}

	public IEnumerable<DepartmentDto> GetDepartmentsLookup()
	{
		var departments = _unitOfWork.Departments.GetActiveDepartments();
		return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
	}

	public bool DeleteDepartment(int id)
	{
		var department = _unitOfWork.Departments.FindById(id);

		if (department is null)
			return false;

		_unitOfWork.Departments.Delete(id);
		_unitOfWork.SaveChanges();

		return true;
	}

	public bool IsDepartmentAllowed(DepartmentFormDto department)
	{
		return _unitOfWork.Departments.IsDepartmentNameAllowed(department.Name, department.Id);
	}
}
