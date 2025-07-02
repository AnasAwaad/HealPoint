using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealPoint.Presentation.Controllers;
public class DoctorSchedulesController : Controller
{
	private readonly IClinicService _clinicService;

	public DoctorSchedulesController(IClinicService clinicService)
	{
		_clinicService = clinicService;
	}

	public IActionResult Create()
	{
		return View("Upsert", PopulateLookups());
	}

	[HttpPost]
	public IActionResult Create(DoctorScheduleDto doctorSchedule)
	{
		if (!ModelState.IsValid)
		{
			return View("Upsert", PopulateLookups(doctorSchedule));
		}
		// Here you would typically call a service to save the doctor schedule
		// _doctorScheduleService.Create(doctorScheduleDto);
		return Ok();
	}

	private DoctorScheduleDto PopulateLookups(DoctorScheduleDto? dto = null)
	{
		var doctorScheduleDto = dto ?? new DoctorScheduleDto();
		var clinics = _clinicService.GetClinicsLookup();

		doctorScheduleDto.Clinics = new SelectList(clinics, "Id", "Name");
		doctorScheduleDto.DoctorScheduleDetails = new List<DoctorScheduleDetailsDto>();
		doctorScheduleDto.DoctorScheduleDetails.Add(new DoctorScheduleDetailsDto { Id = 1 });

		return doctorScheduleDto;
	}
}
