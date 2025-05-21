using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealPoint.BusinessLogic.Services;
public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public IEnumerable<CategoryDto> GetAllCategories()
    {
        var categories = _unitOfWork.Categories.GetAll();
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public CategoryFormDto? GetCategoryById(int id)
    {
        var category = _unitOfWork.Categories.FindById(id);

        return _mapper.Map<CategoryFormDto>(category);
    }

    public CategoryDto? UpdateCategory(CategoryFormDto categoryDto)
    {
        var existingCategory = _unitOfWork.Categories.FindById(categoryDto.Id);

        if (existingCategory == null)
        {
            return null;
        }

        _mapper.Map(categoryDto, existingCategory);
        existingCategory.LastUpdatedOn = DateTime.Now;

        _unitOfWork.SaveChanges();

        var categoryResult = _mapper.Map<CategoryDto>(existingCategory);
        categoryResult.ParentCategoryName = categoryDto.ParentCategoryName;
        return categoryResult;
    }

    public CategoryDto CreateCategory(CategoryFormDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        _unitOfWork.Categories.Insert(category);
        _unitOfWork.SaveChanges();

        var categoryResult = _mapper.Map<CategoryDto>(category);
        categoryResult.ParentCategoryName = categoryDto.ParentCategoryName;

        return categoryResult;
    }

    public string? UpdateFeaturedStatus(int id)
    {
        var existingCategory = _unitOfWork.Categories.FindById(id);

        if (existingCategory == null)
            return null;

        existingCategory.IsFeatured = !existingCategory.IsFeatured;
        existingCategory.LastUpdatedOn = DateTime.Now;

        _unitOfWork.SaveChanges();

        return existingCategory.LastUpdatedOn.ToString();
    }

    public string? UpdateCategoryStatus(int id)
    {
        var existingCategory = _unitOfWork.Categories.FindById(id);

        if (existingCategory == null)
            return null;

        existingCategory.Status = !existingCategory.Status;
        existingCategory.LastUpdatedOn = DateTime.Now;

        _unitOfWork.SaveChanges();

        return existingCategory.LastUpdatedOn.ToString();
    }

    public List<SelectListItem> GetParentCategorySelectList()
    {
        var categories = _unitOfWork.Categories.GetParentCategories();
        return categories.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).OrderBy(c => c.Text).ToList();
    }

    public bool DeleteCategory(int id)
    {
        var category = _unitOfWork.Categories.FindById(id);

        if (category is null)
            return false;

        _unitOfWork.Categories.Delete(id);

        return true;
    }

    public bool IsCategoryAllowed(CategoryFormDto category)
    {
        return _unitOfWork.Categories.IsCategoryNameAllowed(category.Name, category.Id);
    }
}
