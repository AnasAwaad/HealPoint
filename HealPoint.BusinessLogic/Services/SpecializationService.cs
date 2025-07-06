using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs.Specialization;
using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Services;
public class SpecializationService : ISpecializationService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public SpecializationService(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public IEnumerable<SpecializationDto> GetAllSpecializations()
	{
		var specialization = _unitOfWork.Specializations.GetAllSpecializationWithDepartments();
		return _mapper.Map<IEnumerable<SpecializationDto>>(specialization);
	}

	public IEnumerable<SpecializationDto> GetSpecializationsLookup()
	{
		var specializations = _unitOfWork.Specializations.GetActiveSpecializations();

		return _mapper.Map<IEnumerable<SpecializationDto>>(specializations);
	}

	public SpecializationDto CreateSpecialization(SpecializationFormDto specializationDto)
	{
		var spec = _mapper.Map<Specialization>(specializationDto);
		_unitOfWork.Specializations.Insert(spec);
		_unitOfWork.SaveChanges();

		var specResult = _mapper.Map<SpecializationDto>(spec);
		specResult.DepartmentName = specializationDto.DepartmentName;

		return specResult;
	}

	public SpecializationFormDto? GetSpecializationById(int id)
	{
		var specialization = _unitOfWork.Specializations.FindById(id);

		return _mapper.Map<SpecializationFormDto>(specialization);
	}

	public SpecializationDto? UpdateSpecialization(SpecializationFormDto specializationDto)
	{
		var existingSpecialization = _unitOfWork.Specializations.FindById(specializationDto.Id);

		if (existingSpecialization == null)
		{
			return null;
		}

		_mapper.Map(specializationDto, existingSpecialization);
		existingSpecialization.LastUpdatedOn = DateTime.Now;

		_unitOfWork.SaveChanges();

		var specializationResult = _mapper.Map<SpecializationDto>(existingSpecialization);
		specializationResult.DepartmentName = specializationDto.DepartmentName;

		return specializationResult;
	}

	public bool IsSpecializationAllowed(SpecializationFormDto model)
	{
		return _unitOfWork.Specializations.IsSpecializationNameAllowed(model.Name, model.Id);
	}

	public bool? UpdateSpecializationStatus(int id)
	{
		var existingSpecialization = _unitOfWork.Specializations.FindById(id);

		if (existingSpecialization == null)
			return null;

		existingSpecialization.IsDeleted = !existingSpecialization.IsDeleted;
		existingSpecialization.LastUpdatedOn = DateTime.Now;

		_unitOfWork.SaveChanges();

		return existingSpecialization.IsDeleted;
	}

	public IEnumerable<DoctorSpecializationItemDto> GetActiveServicesForDoctor()
	{
		var specializations = _unitOfWork.Specializations.GetActiveSpecializations();
		return _mapper.Map<IEnumerable<DoctorSpecializationItemDto>>(specializations);
	}
}
