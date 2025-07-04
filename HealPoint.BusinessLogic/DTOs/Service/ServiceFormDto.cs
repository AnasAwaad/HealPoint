using HealPoint.DataAccess.Consts;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HealPoint.BusinessLogic.DTOs;
public class ServiceFormDto
{
	public int Id { get; set; }
	[MaxLength(100, ErrorMessage = Errors.MaxLengthExceeded)]
	[Remote("AllowedDepartmentName", "Departments", AdditionalFields = "Id", ErrorMessage = Errors.Dublicated)]
	public string Name { get; set; } = null!;

	[MaxLength(500, ErrorMessage = Errors.MaxLengthExceeded)]
	public string? Description { get; set; }
}
