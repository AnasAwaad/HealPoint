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
	public IActionResult Index()
	{
		return View(_doctorService.GetAll());
	}


	public IActionResult Create()
	{
		return View();
	}
	#endregion

}
