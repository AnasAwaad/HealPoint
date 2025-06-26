using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HealPoint.BusinessLogic.DTOs;
public class CreateClinicDto
{
	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
	public IFormFile ImageFile { get; set; }
	public string Email { get; set; } = null!;
	public string ContactNumber { get; set; } = null!;
	[Display(Name = "Specialization")]
	public int SpecializationId { get; set; }
	public IEnumerable<SelectListItem> SpecializationSelectList { get; set; } = new List<SelectListItem>();
	public bool Status { get; set; } = true;
	public string Address { get; set; } = null!;
	public string Country { get; set; } = null!;
	public string State { get; set; } = null!;
	public string City { get; set; } = null!;
	public string PostalCode { get; set; } = null!;
	public double? Latitude { get; set; }
	public double? Longitude { get; set; }
}
