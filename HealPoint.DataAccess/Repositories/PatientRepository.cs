using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Data;

namespace HealPoint.DataAccess.Repositories;
internal class PatientRepository : Repository<Patient>, IPatientRepository
{
	public PatientRepository(ApplicationDbContext context) : base(context)
	{
	}

	public IQueryable<Patient> GetAllWithDetails()
	{
		return _context.Patients
			.Include(p => p.User)
			.AsQueryable();
	}
}
