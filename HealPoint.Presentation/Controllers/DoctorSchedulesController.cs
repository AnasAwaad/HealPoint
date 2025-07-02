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

		foreach (var item in model.DoctorScheduleDetails)
		{
			if (item.StartTime >= item.EndTime)
			{
				return BadRequest($"Start Time must be before End Time on {item.DayOfWeek}");
			}
		}

		//_doctorScheduleService.Create(model, User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
		return Ok();
	}

	private DoctorScheduleDto PopulateLookups(DoctorScheduleDto? dto = null)
	{
		var doctorScheduleDto = dto ?? new DoctorScheduleDto();
		var clinics = _clinicService.GetClinicsLookup();

		doctorScheduleDto.Clinics = new SelectList(clinics, "Id", "Name");

		if (!doctorScheduleDto.DoctorScheduleDetails.Any())
		{
			doctorScheduleDto.DoctorScheduleDetails = new List<DoctorScheduleDetailsDto>();
			doctorScheduleDto.DoctorScheduleDetails.Add(new DoctorScheduleDetailsDto { Id = 1 });
		}
		return doctorScheduleDto;
	}
}
