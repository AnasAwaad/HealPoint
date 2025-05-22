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

	public IEnumerable<Category> GetSubCategories()
	{
		return _context.Categories
			.Where(c => !c.IsDeleted && c.ParentCategoryId != null)
			.AsEnumerable();
	}

	// Perform soft delete: Set IsDeleted to true instead of removing
	public override void Delete(int id)
	{
		var category = _context.Categories.Find(id);
		if (category != null)
		{

			category.IsDeleted = true;
			category.LastUpdatedOn = DateTime.Now;
			_context.SaveChanges();
		}
	}

	public bool IsCategoryNameAllowed(string categoryName, int? excludeCategoryId = null)
	{
		var category = _context.Categories.SingleOrDefault(c => c.Name == categoryName && !c.IsDeleted);

		return category is null || category.Id.Equals(excludeCategoryId);
	}
}
