using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

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
		var specialization = _unitOfWork.Specializations.GetAllSpecializationWithCategories();
		return _mapper.Map<IEnumerable<SpecializationDto>>(specialization);
	}

	public IEnumerable<SpecializationDto> GetSpecializationsLookup()
	{
		var specializations = _unitOfWork.Specializations.GetActiveSpecializations();

		return _mapper.Map<IEnumerable<SpecializationDto>>(specializations);
	}

	public List<SelectListItem> GetCategorySelectList()
	{
		var categories = _unitOfWork.Categories.GetSubCategories();
		return categories.Select(c => new SelectListItem
		{
			Text = c.Name,
			Value = c.Id.ToString()
		}).OrderBy(s => s.Text).ToList();
	}

	public SpecializationDto CreateSpecialization(SpecializationFormDto specializationDto)
	{
		var spec = _mapper.Map<Specialization>(specializationDto);
		_unitOfWork.Specializations.Insert(spec);
		_unitOfWork.SaveChanges();

		var specResult = _mapper.Map<SpecializationDto>(spec);
		specResult.CategoryName = specializationDto.CategoryName;

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
		specializationResult.CategoryName = specializationDto.CategoryName;

		return specializationResult;
	}

	public bool IsSpecializationAllowed(SpecializationFormDto model)
	{
		return _unitOfWork.Specializations.IsSpecializationNameAllowed(model.Name, model.Id);
	}

	public string? UpdateSpecializationStatus(int id)
	{
		var existingSpecialization = _unitOfWork.Specializations.FindById(id);

		if (existingSpecialization == null)
			return null;

		existingSpecialization.Status = !existingSpecialization.Status;
		existingSpecialization.LastUpdatedOn = DateTime.Now;

		_unitOfWork.SaveChanges();

		return existingSpecialization.LastUpdatedOn.ToString();
	}

	public bool DeleteSpecialization(int id)
	{
		var specialization = _unitOfWork.Specializations.FindById(id);

		if (specialization is null)
			return false;

		_unitOfWork.Specializations.Delete(id);
		_unitOfWork.SaveChanges();

		return true;
	}

	public List<SelectListItem> GetSpecializationSelectList()
	{
		var specialization = _unitOfWork.Specializations.GetAll();

		return specialization.Select(s => new SelectListItem
		{
			Text = s.Name,
			Value = s.Id.ToString()
		}).ToList();
	}
}
