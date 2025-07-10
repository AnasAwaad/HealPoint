using HealPoint.BusinessLogic.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HealPoint.Presentation.Controllers;
public class DoctorsController : Controller
{
	#region Props
	private readonly IDoctorService _doctorService;
	#endregion

	#region Ctor
	public DoctorsController(IDoctorService doctorService)
	{
		_doctorService = doctorService;
	}
	#endregion

	#region Actions
	public IActionResult Details(int id)
	{
		var doctor = _doctorService.GetDoctorDetailsWithSchedule(id);
		return View(doctor);
	}

	[HttpGet]
	public IActionResult GetDoctorSchedulesForDate(int doctorId, string date)
	{
		if (!DateTime.TryParse(date, out DateTime parsedDate))
			return BadRequest("Invalid date format");

		var slots = _doctorService.GetAvailableTimesForDay(doctorId, parsedDate);


		return Ok(slots);
	}
	#endregion

}
