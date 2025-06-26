using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealPoint.BusinessLogic.Contracts;
public interface ISpecializationService
{
	IEnumerable<SpecializationDto> GetAllSpecializations();
	List<SelectListItem> GetCategorySelectList();
	IEnumerable<SpecializationDto> GetSpecializationsLookup();
	SpecializationFormDto? GetSpecializationById(int id);
	SpecializationDto CreateSpecialization(SpecializationFormDto specializationDto);
	SpecializationDto? UpdateSpecialization(SpecializationFormDto specializationDto);
	bool IsSpecializationAllowed(SpecializationFormDto model);
	bool? UpdateSpecializationStatus(int id);
	List<SelectListItem> GetSpecializationSelectList();

}
