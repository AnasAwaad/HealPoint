using HealPoint.BusinessLogic.DTOs;

namespace HealPoint.BusinessLogic.Contracts;
public interface IClinicSessionService
{
    IEnumerable<ClinicSessionDto> GetSessionsByClinicId(int clinicId);
    void SaveClinicSessions(IEnumerable<ClinicSessionDto> clinicSessionDtos);
}
