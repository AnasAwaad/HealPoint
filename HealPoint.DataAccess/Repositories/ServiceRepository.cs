using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Data;

namespace HealPoint.DataAccess.Repositories;
internal class ServiceRepository : Repository<Service>, IServiceRepository
{
	public ServiceRepository(ApplicationDbContext context) : base(context)
	{
	}

	public IEnumerable<Service> GetActiveServices()
	{
		return _context.Services
			.Where(s => !s.IsDeleted)
			.AsEnumerable();
	}
}
