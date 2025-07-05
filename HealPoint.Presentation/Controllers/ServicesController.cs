using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.Presentation.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HealPoint.Presentation.Controllers;
public class ServicesController : Controller
{
	#region Props
	private readonly IServiceManager _serviceManager;

	#endregion

	#region Ctor

	public ServicesController(IServiceManager serviceManager)
	{
		_serviceManager = serviceManager;
	}
	#endregion

	#region Actions

	public IActionResult Index()
	{
		return View(_serviceManager.GetAllServices());
	}

	[AjaxOnly]
	public IActionResult Create()
	{
		return PartialView("_Form");
	}

	[AjaxOnly]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Create(ServiceFormDto model)
	{
		if (!ModelState.IsValid)
			return BadRequest();

		var service = _serviceManager.CreateService(model);

		return PartialView("_ServiceRow", service);
	}

	[AjaxOnly]
	public IActionResult Update(int id)
	{
		return PartialView("_Form", _serviceManager.GetServiceById(id));
	}

	[AjaxOnly]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Update(ServiceFormDto model)
	{
		if (!ModelState.IsValid)
			return BadRequest();

		var serviceDto = _serviceManager.UpdateService(model);

		if (serviceDto == null)
			return NotFound();

		return PartialView("_ServiceRow", serviceDto);
	}


	[AjaxOnly]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult ChangeServiceStatus(int id)
	{
		(bool? isDeleted, string? lastUpdatedOn) = _serviceManager.UpdateServiceStatus(id);

		if (isDeleted is null)
			return NotFound();

		return Ok(new { isDeleted, lastUpdatedOn });
	}


	#endregion

}
