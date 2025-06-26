using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HealPoint.BusinessLogic.DTOs;
public class DepartmentFormDto
{
	public int Id { get; set; }
	[MaxLength(100, ErrorMessage = "Max length can't be more than 100 characters.")]
	[Remote("AllowedDepartmentName", "Departments", AdditionalFields = "Id", ErrorMessage = "Department with the same name is already exists.")]
	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
}
