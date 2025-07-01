using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealPoint.Presentation.Controllers;
public class DoctorSchedulesController : Controller
{
	private readonly ITimeSlotService _timeSlotService;

	public DoctorSchedulesController(ITimeSlotService timeSlotService)
	{
		_timeSlotService = timeSlotService;
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

	public IActionResult Create()
	{
		return PartialView("_Form");
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Create(TimeSlotDto model)
	{
		if (!ModelState.IsValid)
			return BadRequest();

		_timeSlotService.CreateTimeSlot(model, User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
		return Ok();
	}
}
