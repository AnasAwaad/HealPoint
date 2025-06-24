using HealPoint.BusinessLogic.DTOs;

namespace HealPoint.BusinessLogic.Contracts;
public interface IClinicSessionService
{
    ClinicSessionListDto GetSessionsByClinicId(int clinicId);
    void SaveClinicSessions(IEnumerable<ClinicSessionDto> clinicSessionDtos);
}
