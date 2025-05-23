using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Repositories;

namespace HealPoint.DataAccess.Data;
internal class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    private readonly Lazy<ISpecializationRepository> _specializationRepository;
    private readonly Lazy<ICategoryRepository> _categoryRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        _specializationRepository = new Lazy<ISpecializationRepository>(new SpecializationRepository(_context));
        _categoryRepository = new Lazy<ICategoryRepository>(new CategoryRepository(_context));
    }

    public ISpecializationRepository Specializations => _specializationRepository.Value;

    public ICategoryRepository Categories => _categoryRepository.Value;

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}