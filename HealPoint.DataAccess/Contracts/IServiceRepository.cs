﻿namespace HealPoint.DataAccess.Contracts;
public interface IServiceRepository : IRepository<Service>
{
	IEnumerable<Service> GetActiveServices();
}
