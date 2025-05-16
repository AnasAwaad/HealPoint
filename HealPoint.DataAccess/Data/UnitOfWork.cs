using Vezeeta.DataAccess.Contracts;

namespace Vezeeta.DataAccess.Data;
internal class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    //private readonly Lazy<IProductRepository> _productRepository;
    //private readonly Lazy<ICategoryRepository> _categoryRepository;


    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        //_productRepository = new Lazy<IProductRepository>(new ProductRepository(_context));
        //_categoryRepository = new Lazy<ICategoryRepository>(new CategoryRepository(_context));





    }

    public void Dispose()
    {
        _context.Dispose();
    }

    //public IProductRepository Products => _productRepository.Value;

    //public ICategoryRepository Categories => _categoryRepository.Value;

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}