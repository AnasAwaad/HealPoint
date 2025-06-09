namespace HealPoint.DataAccess.Contracts;
public interface IClinicSessionRepository : IRepository<ClinicSession>
{
    IEnumerable<ClinicSession> GetByClinicId(int clinicId);
}
