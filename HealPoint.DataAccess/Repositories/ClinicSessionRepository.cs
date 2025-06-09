using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Data;

namespace HealPoint.DataAccess.Repositories;
internal class ClinicSessionRepository : Repository<ClinicSession>, IClinicSessionRepository
{
    public ClinicSessionRepository(ApplicationDbContext context) : base(context)
    {
    }

    public IEnumerable<ClinicSession> GetByClinicId(int clinicId)
    {
        return _context.ClinicSessions
            .Where(cs => cs.ClinicId == clinicId)
            .Include(cs => cs.Clinic)
            .AsEnumerable();
    }
}
