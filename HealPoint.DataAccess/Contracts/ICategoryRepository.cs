namespace HealPoint.DataAccess.Contracts;
public interface ICategoryRepository : IRepository<Category>
{
	IEnumerable<Category> GetParentCategories();
	IEnumerable<Category> GetSubCategories();
	bool IsCategoryNameAllowed(string categoryName, int? excludeCategoryId = null);
}
