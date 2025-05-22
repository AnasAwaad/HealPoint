namespace HealPoint.DataAccess.Contracts;
public interface IUnitOfWork : IDisposable
{
    ICategoryRepository Categories { get; }
    ISpecializationRepository Specializations { get; }

    void SaveChanges();
}
