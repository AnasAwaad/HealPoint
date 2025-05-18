using HealPoint.BusinessLogic.DTOs;

namespace HealPoint.BusinessLogic.Contracts;
public interface ICategoryService
{
    IEnumerable<CategoryListDto> GetAllCategories();
    void CreateCategory(CategoryFormDto category);
    CategoryFormDto GetCategoryById(int id);
    bool UpdateCategory(CategoryFormDto category);
    bool ChangeStatus(int id);
}
