using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Data;

namespace HealPoint.DataAccess.Repositories;
internal class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }


    public override IEnumerable<Category> GetAll()
    {
        return _context.Categories
            .AsNoTracking()
            .Where(c => !c.IsDeleted)
            .Include(c => c.ParentCategory)
            .AsEnumerable();
    }

    public IEnumerable<Category> GetParentCategories()
    {
        return _context.Categories
            .AsNoTracking()
            .Where(c => c.ParentCategoryId == null && !c.IsDeleted)
            .AsEnumerable();
    }
}
