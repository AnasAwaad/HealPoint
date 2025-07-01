using HealPoint.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HealPoint.Presentation.Controllers;
public class DoctorSchedulesController : Controller
{
	public IActionResult Index()
	{
		var doctorSchedule = new DoctorScheduleDto();
		doctorSchedule.DoctorScheduleDetails.Add(new DoctorScheduleDetailsDto { Id = 1 });
		//doctorSchedule.DoctorScheduleDetails.Add(new DoctorScheduleDetailsDto { Id = 2 });
		//doctorSchedule.DoctorScheduleDetails.Add(new DoctorScheduleDetailsDto { Id = 3 });

		return View(doctorSchedule);
	}
}
