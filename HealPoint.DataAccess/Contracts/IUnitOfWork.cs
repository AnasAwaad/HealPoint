namespace HealPoint.DataAccess.Contracts;
public interface IUnitOfWork : IDisposable
{
	//IProductRepository Products { get; }
	ICategoryRepository Categories { get; }

	void SaveChanges();
}
