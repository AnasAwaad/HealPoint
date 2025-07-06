using HealPoint.BusinessLogic.DTOs.Specialization;

namespace HealPoint.BusinessLogic.Contracts;
public interface ISpecializationService
{
	IEnumerable<SpecializationDto> GetAllSpecializations();
	IEnumerable<SpecializationDto> GetSpecializationsLookup();
	IEnumerable<DoctorSpecializationItemDto> GetActiveServicesForDoctor();
	SpecializationFormDto? GetSpecializationById(int id);
	SpecializationDto CreateSpecialization(SpecializationFormDto specializationDto);
	SpecializationDto? UpdateSpecialization(SpecializationFormDto specializationDto);
	bool IsSpecializationAllowed(SpecializationFormDto model);
	bool? UpdateSpecializationStatus(int id);

}
