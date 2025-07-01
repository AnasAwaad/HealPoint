using HealPoint.BusinessLogic.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealPoint.Presentation.Controllers;
public class DoctorSchedulesController : Controller
{
	private readonly ITimeSlotService _timeSlotService;
	private readonly IDoctorService _doctorService;

	public DoctorSchedulesController(ITimeSlotService timeSlotService, IDoctorService doctorService)
	{
		_timeSlotService = timeSlotService;
		_doctorService = doctorService;
	}

	public IActionResult Index()
	{
		return View();
	}

	public IActionResult GetDayTimeSlots(string day)
	{
		if (!Enum.TryParse<DayOfWeek>(day, out var dayOfWeek))
			return BadRequest("Invalid day");

		var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

		var slots = _timeSlotService.GetTimeSlots(userId, dayOfWeek);

		return PartialView("_DayTimeSlotsPartial", slots);

	}
}
