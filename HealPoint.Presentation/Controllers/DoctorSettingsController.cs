using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HealPoint.Presentation.Controllers;
public class DoctorSettingsController : Controller
{
	#region Props
	private readonly IServiceManager _serviceManager;
	private readonly IDoctorService _doctorService;

	#endregion

	#region Ctor
	public DoctorSettingsController(IServiceManager serviceManager, IDoctorService doctorService)
	{
		_serviceManager = serviceManager;
		_doctorService = doctorService;
	}
	#endregion


	#region Actions
	public IActionResult Index()
	{
		var doctor = _doctorService.GetByUserId(User.GetUserId());

		if (doctor is null)
			return NotFound();

		var model = new DoctorSettingDto
		{
			DoctorId = doctor.Id,
			AvailableServices = _serviceManager.GetActiveServicesForDoctor(),
			SelectedServiceId = doctor.ServiceId
		};

		return View(model);
	}

	[HttpPost]
	public IActionResult UpdateService([FromBody] DoctorSettingDto model)
	{
		if (!model.SelectedServiceId.HasValue || model.SelectedServiceId.Equals(0))
			return BadRequest("Selected service ID cannot be zero.");

		_doctorService.ChangeService(model.DoctorId, model.SelectedServiceId.Value);
		return Ok();
	}
	#endregion
}
