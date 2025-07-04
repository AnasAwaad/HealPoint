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

	#endregion

}
