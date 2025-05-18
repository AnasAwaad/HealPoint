namespace HealPoint.DataAccess.Contracts;
public interface IRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> GetAll(bool noTracking = true);

    TEntity? FindById(int id);

    void Delete(int id);

    void Update(TEntity entity);

    void Insert(TEntity entity);
}
