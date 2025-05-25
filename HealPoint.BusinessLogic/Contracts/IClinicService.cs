using HealPoint.BusinessLogic.DTOs;

namespace HealPoint.BusinessLogic.Contracts;
public interface IClinicService
{
    IEnumerable<ClinicListDto> GetAllClinics();
}
