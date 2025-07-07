using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Data;

namespace HealPoint.DataAccess.Repositories;
internal class PatientRepository : Repository<Patient>, IPatientRepository
{
	public PatientRepository(ApplicationDbContext context) : base(context)
	{
	}
}
