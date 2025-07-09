using HealPoint.BusinessLogic.Contracts;
using HealPoint.DataAccess.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealPoint.Presentation.Areas.Admin.Controllers;

[Authorize(Roles = AppRoles.Admin)]
[Area("Admin")]
public class PatientsController : Controller
{
	#region Props
	private readonly IPatientService _patientService;


	#endregion

	#region Ctor
	public PatientsController(IPatientService patientService)
	{
		_patientService = patientService;
	}
	#endregion

	#region Actions
	public IActionResult Index()
	{
		return View(_patientService.GetAllPatientsWithDetails());
	}
	#endregion

}
