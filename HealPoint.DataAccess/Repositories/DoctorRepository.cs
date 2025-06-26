using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Data;

namespace HealPoint.DataAccess.Repositories;
internal class DoctorRepository : Repository<Doctor>, IDoctorRepository
{
	public DoctorRepository(ApplicationDbContext context) : base(context)
	{
	}

	public IEnumerable<Doctor> GetAllWithDetails()
	{
		return _context.Doctors
			.Include(d => d.Specialization)
			.Include(d => d.ApplicationUser).AsEnumerable();
	}
}
