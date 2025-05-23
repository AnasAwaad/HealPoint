using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HealPoint.BusinessLogic.DTOs;
public class SpecializationFormDto
{
	public int Id { get; set; }
	[MaxLength(100, ErrorMessage = "Max length can't be more than 100 characters.")]
	[Remote("AllowedSpecializationName", "Specializations", AdditionalFields = "Id", ErrorMessage = "Specialization with the same name is already exists.")]
	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
	public string? CategoryName { get; set; }
	public int? CategoryId { get; set; }
	public List<SelectListItem> CategoryOptions { get; set; } = new List<SelectListItem>();
}
