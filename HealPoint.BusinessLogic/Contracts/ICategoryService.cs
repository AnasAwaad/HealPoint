﻿using HealPoint.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealPoint.BusinessLogic.Contracts;
public interface ICategoryService
{
    IEnumerable<CategoryDto> GetAllCategories();
    CategoryFormDto? GetCategoryById(int id);
    List<SelectListItem> GetParentCategorySelectList();
    CategoryDto CreateCategory(CategoryFormDto category);
    CategoryDto? UpdateCategory(CategoryFormDto category);
    string? UpdateFeaturedStatus(int id);
    string? UpdateCategoryStatus(int id);
    bool DeleteCategory(int id);

    bool IsCategoryAllowed(CategoryFormDto category);
}
