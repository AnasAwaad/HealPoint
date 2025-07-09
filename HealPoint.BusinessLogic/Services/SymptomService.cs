using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Services;
internal class SymptomService : ISymptomService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public SymptomService(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public IEnumerable<SymptomDto> GetAllSymptoms()
	{
		var symptoms = _unitOfWork.Symptoms.GetAll();
		return _mapper.Map<IEnumerable<SymptomDto>>(symptoms);
	}

	public SymptomFormDto? GetSymptomById(int id)
	{
		var department = _unitOfWork.Symptoms.FindById(id);

		return _mapper.Map<SymptomFormDto>(department);
	}

	public SymptomDto? UpdateSymptom(SymptomFormDto departmentDto)
	{
		var existingSymptom = _unitOfWork.Symptoms.FindById(departmentDto.Id);

		if (existingSymptom == null)
		{
			return null;
		}

		_mapper.Map(departmentDto, existingSymptom);
		existingSymptom.LastUpdatedOn = DateTime.Now;

		_unitOfWork.SaveChanges();

		return _mapper.Map<SymptomDto>(existingSymptom);
	}

	public SymptomDto CreateSymptom(SymptomFormDto departmentDto)
	{
		var department = _mapper.Map<Symptom>(departmentDto);
		_unitOfWork.Symptoms.Insert(department);
		_unitOfWork.SaveChanges();

		return _mapper.Map<SymptomDto>(department);
	}

	public (bool? isDeleted, string? lastUpdatedOn) UpdateSymptomStatus(int id)
	{
		var existingSymptom = _unitOfWork.Symptoms.FindById(id);

		if (existingSymptom == null)
			return (null, null);

		existingSymptom.IsDeleted = !existingSymptom.IsDeleted;
		existingSymptom.LastUpdatedOn = DateTime.Now;

		_unitOfWork.SaveChanges();

		return (existingSymptom.IsDeleted, DateTime.Now.ToString("dddd, dd MMMM yyyy h:mm tt"));
	}

	public IEnumerable<SymptomDto> GetSymptomsLookup()
	{
		var symptoms = _unitOfWork.Symptoms.GetActiveSymptoms();
		return _mapper.Map<IEnumerable<SymptomDto>>(symptoms);
	}

	public bool DeleteSymptom(int id)
	{
		var department = _unitOfWork.Symptoms.FindById(id);

		if (department is null)
			return false;

		_unitOfWork.Symptoms.Delete(id);
		_unitOfWork.SaveChanges();

		return true;
	}

	public bool IsSymptomAllowed(SymptomFormDto department)
	{
		return _unitOfWork.Symptoms.IsSymptomNameAllowed(department.Name, department.Id);
	}

	public IEnumerable<SymptomDto> GetActiveSymptoms()
	{
		var symptoms = _unitOfWork.Symptoms.GetActiveSymptoms();
		return _mapper.Map<IEnumerable<SymptomDto>>(symptoms);
	}
}
