namespace HealPoint.BusinessLogic.Contracts;
public interface ISpecializationService
{
	IEnumerable<SpecializationDto> GetAllSpecializations();
	IEnumerable<SpecializationDto> GetSpecializationsLookup();
	SpecializationFormDto? GetSpecializationById(int id);
	SpecializationDto CreateSpecialization(SpecializationFormDto specializationDto);
	SpecializationDto? UpdateSpecialization(SpecializationFormDto specializationDto);
	bool IsSpecializationAllowed(SpecializationFormDto model);
	bool? UpdateSpecializationStatus(int id);

}
