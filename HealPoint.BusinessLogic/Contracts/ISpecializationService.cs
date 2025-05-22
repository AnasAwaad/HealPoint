using HealPoint.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealPoint.BusinessLogic.Contracts;
public interface ISpecializationService
{
	IEnumerable<SpecializationDto> GetAllSpecializations();
	List<SelectListItem> GetCategorySelectList();
	SpecializationDto CreateSpecialization(SpecializationFormDto specializationDto);
}
