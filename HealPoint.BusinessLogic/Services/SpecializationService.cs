using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
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
		var specialization = _unitOfWork.Specializations.GetAll();
		return _mapper.Map<IEnumerable<SpecializationDto>>(specialization);
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
}
