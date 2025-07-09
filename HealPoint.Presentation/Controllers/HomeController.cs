using HealPoint.BusinessLogic.Contracts;
using HealPoint.Presentation.Models;
using HealPoint.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HealPoint.Presentation.Controllers;

public class HomeController : Controller
{
	#region Props
	private readonly IServiceManager _serviceManager;
	private readonly ISpecializationService _specializationService;
	private readonly ISymptomService _symptomService;
	private readonly IDoctorService _doctorService;
	#endregion

	#region Ctor
	public HomeController(IServiceManager serviceManager, ISpecializationService specializationService, ISymptomService symptomService, IDoctorService doctorService)
	{
		_serviceManager = serviceManager;
		_specializationService = specializationService;
		_symptomService = symptomService;
		_doctorService = doctorService;
	}
	#endregion

	#region Actions
	public IActionResult Index()
	{
		var services = _serviceManager.GetActiveServices();
		var specialities = _specializationService.GetActiveSpecializations();
		var symptoms = _symptomService.GetActiveSymptoms();
		var doctors = _doctorService.GetAllDoctorsWithAvailableTimes(DateTime.Now);
		var viewModel = new HomeViewModel
		{
			Services = services,
			Specializations = specialities,
			Symptoms = symptoms,
			Doctors = doctors,
		};
		return View(viewModel);
	}

	public IActionResult Privacy()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
	#endregion
}
