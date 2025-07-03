using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealPoint.BusinessLogic.DTOs;
public class DoctorScheduleDto
{
	public int Id { get; set; }
	public string StartDate { get; set; }
	public string EndDate { get; set; }
	public string Recurrence { get; set; }
	public int ClinicId { get; set; }
	public IEnumerable<SelectListItem>? Clinics { get; set; } = new List<SelectListItem>();

	public List<DoctorScheduleDetailsDto>? DoctorScheduleDetails { get; set; }
}
