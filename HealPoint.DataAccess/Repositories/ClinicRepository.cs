using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Data;

namespace HealPoint.DataAccess.Repositories;
internal class ClinicRepository : Repository<Clinic>, IClinicRepository
{
	public ClinicRepository(ApplicationDbContext context) : base(context)
	{
	}



	public Clinic? GetClinicWithSpecializations(int id)
	{
		return _context.Clinics
			.Where(c => !c.IsDeleted)
			.Include(c => c.Specialization)
			.FirstOrDefault();
	}
}
