using HealPoint.BusinessLogic.DTOs;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Contracts;
public interface ICategoryService
{
    IEnumerable<CategoryListDto> GetAllCategories();
    void CreateCategory(CreateCategoryDto category);
    Category GetCategoryById(int id);
    void UpdateCategory(Category category);
    void DeleteCategory(int id);
}
