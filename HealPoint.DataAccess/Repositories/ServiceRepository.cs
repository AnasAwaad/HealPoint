using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Data;

namespace HealPoint.DataAccess.Repositories;
internal class ServiceRepository : Repository<Service>, IServiceRepository
{
	public ServiceRepository(ApplicationDbContext context) : base(context)
	{
	}
}
