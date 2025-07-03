using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HealPoint.BusinessLogic.DTOs;
public class DoctorScheduleDto
{
	public int Id { get; set; }
	public string StartDate { get; set; }
	public string EndDate { get; set; }

	[Required(ErrorMessage = "Recurrence pattern is required")]
	public int Recurrence { get; set; }

	[Required(ErrorMessage = "Clinic is required")]
	public int ClinicId { get; set; }
	public IEnumerable<SelectListItem>? Clinics { get; set; } = new List<SelectListItem>();

	public List<DoctorScheduleDetailsDto>? DoctorScheduleDetails { get; set; }

}
