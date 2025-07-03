using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace HealPoint.Presentation.Controllers;
public class DoctorSchedulesController : Controller
{
	private readonly IClinicService _clinicService;
	private readonly IDoctorScheduleService _doctorScheduleService;

	public DoctorSchedulesController(IClinicService clinicService, IDoctorScheduleService doctorScheduleService)
	{
		_clinicService = clinicService;
		_doctorScheduleService = doctorScheduleService;
	}

	public IActionResult Create()
	{
		var doctorSchedules = _doctorScheduleService.GetAllWithDetails(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
		return View("Upsert", PopulateLookups(doctorSchedules));
	}

	[HttpPost]
	public IActionResult Create([FromBody] DoctorScheduleDto model)
	{
		if (!ModelState.IsValid)
		{
			return View("Upsert", PopulateLookups(model));
		}

		//foreach (var item in model.DoctorScheduleDetails)
		//{
		//	if (item.StartTime >= item.EndTime)
		//	{
		//		return BadRequest($"Start Time must be before End Time on {item.DayOfWeek}");
		//	}
		//}

		_doctorScheduleService.Create(model, User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
		return Ok(new { success = true, message = "Doctor schedule created successfully" });
	}

	[HttpPost]
	public IActionResult Update([FromBody] DoctorScheduleDto model)
	{
		if (!ModelState.IsValid)
		{
			return View("Upsert", PopulateLookups(model));
		}
		//foreach (var item in model.DoctorScheduleDetails)
		//{
		//	if (TimeSpan.Compare(item.StartTime, item.EndTime) == 1)
		//	{
		//		return BadRequest($"Start Time must be before End Time on {item.DayOfWeek}");
		//	}
		//}
		_doctorScheduleService.Update(model, User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
		return Ok(new { success = true, message = "Doctor schedule updated successfully" });
	}

	private DoctorScheduleDto PopulateLookups(DoctorScheduleDto? dto = null)
	{
		var doctorScheduleDto = dto ?? new DoctorScheduleDto();
		var clinics = _clinicService.GetClinicsLookup();

		doctorScheduleDto.Clinics = new SelectList(clinics, "Id", "Name");

		if (!(doctorScheduleDto.DoctorScheduleDetails?.Count > 0))
		{
			doctorScheduleDto.DoctorScheduleDetails = new List<DoctorScheduleDetailsDto>();
			doctorScheduleDto.DoctorScheduleDetails.Add(new DoctorScheduleDetailsDto { DayOfWeek = "Sunday" });
			doctorScheduleDto.DoctorScheduleDetails.Add(new DoctorScheduleDetailsDto { DayOfWeek = "Monday" });
			doctorScheduleDto.DoctorScheduleDetails.Add(new DoctorScheduleDetailsDto { DayOfWeek = "Tuesday" });
			doctorScheduleDto.DoctorScheduleDetails.Add(new DoctorScheduleDetailsDto { DayOfWeek = "Wednesday" });
			doctorScheduleDto.DoctorScheduleDetails.Add(new DoctorScheduleDetailsDto { DayOfWeek = "Thursday" });
			doctorScheduleDto.DoctorScheduleDetails.Add(new DoctorScheduleDetailsDto { DayOfWeek = "Friday" });
			doctorScheduleDto.DoctorScheduleDetails.Add(new DoctorScheduleDetailsDto { DayOfWeek = "Saturday" });
		}
		return doctorScheduleDto;
	}
}
