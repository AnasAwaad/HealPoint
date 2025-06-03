using HealPoint.BusinessLogic.DTOs;

namespace HealPoint.BusinessLogic.Contracts;
public interface IClinicService
{
	IEnumerable<ClinicListDto> GetAllClinics();
	Task CreateClinicAsync(CreateClinicDto clinicDto);

	UpdateClinicDto? GetClinicById(int id);

	Task<UpdateClinicDto?> UpdateClinicAsync(UpdateClinicDto clinicDto);
	bool DeleteClinic(int id);
}
