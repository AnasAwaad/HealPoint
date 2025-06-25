namespace HealPoint.DataAccess.Contracts;
public interface IClinicSessionRepository : IRepository<ClinicSession>
{
    IEnumerable<ClinicSession> GetAllSessionsByClinicId(int clinicId);
    void RemoveRange(IEnumerable<ClinicSession> clinicSessions);
}
