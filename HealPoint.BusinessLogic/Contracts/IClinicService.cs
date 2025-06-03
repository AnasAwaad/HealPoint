using HealPoint.BusinessLogic.DTOs;

namespace HealPoint.BusinessLogic.Contracts;
public interface IClinicService
{
    IEnumerable<ClinicListDto> GetAllClinics();
    Task CreateClinic(CreateClinicDto clinicDto);

    UpdateClinicDto? GetClinicById(int id);

    UpdateClinicDto? UpdateClinic(UpdateClinicDto clinicDto);
    bool DeleteClinic(int id);
}
