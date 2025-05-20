using HealPoint.BusinessLogic.DTOs;

namespace HealPoint.BusinessLogic.Contracts;
public interface ICategoryService
{
	IEnumerable<CategoryDto> GetAllCategories();
	CategoryDto CreateCategory(CategoryFormDto category);
	CategoryFormDto? GetCategoryById(int id);
	CategoryDto? UpdateCategory(CategoryFormDto category);
	DateTime? ChangeStatus(int id);
}
