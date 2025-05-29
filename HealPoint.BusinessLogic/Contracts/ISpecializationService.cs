using HealPoint.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealPoint.BusinessLogic.Contracts;
public interface ISpecializationService
{
	IEnumerable<SpecializationDto> GetAllSpecializations();
	List<SelectListItem> GetCategorySelectList();
	SpecializationFormDto? GetSpecializationById(int id);
	SpecializationDto CreateSpecialization(SpecializationFormDto specializationDto);
	SpecializationDto? UpdateSpecialization(SpecializationFormDto specializationDto);
	bool DeleteSpecialization(int id);
	bool IsSpecializationAllowed(SpecializationFormDto model);
	string? UpdateSpecializationStatus(int id);
	List<SelectListItem> GetSpecializationSelectList();

}
