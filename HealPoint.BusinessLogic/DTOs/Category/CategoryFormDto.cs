using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HealPoint.BusinessLogic.DTOs;
public class CategoryFormDto
{
    public int Id { get; set; }
    [MaxLength(100, ErrorMessage = "Max length can't be more than 100 characters.")]
    [Remote("AllowedCategoryName", "Categories", AdditionalFields = "Id", ErrorMessage = "Category with the same name is already exists.")]
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? ParentCategoryName { get; set; }
    public int? ParentCategoryId { get; set; }
    public List<SelectListItem> ParentCategoryOptions { get; set; } = new List<SelectListItem>();
}
