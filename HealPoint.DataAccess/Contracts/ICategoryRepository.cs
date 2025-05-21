namespace HealPoint.DataAccess.Contracts;
public interface ICategoryRepository : IRepository<Category>
{
    IEnumerable<Category> GetParentCategories();
    bool IsCategoryNameAllowed(string categoryName, int? excludeCategoryId = null);
}
