using HealPoint.BusinessLogic.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HealPoint.Presentation.Controllers;
public class ClinicsController : Controller
{
    private readonly IClinicService _clinicService;

    public ClinicsController(IClinicService clinicService)
    {
        _clinicService = clinicService;
    }

    public IActionResult Index()
    {
        return View(_clinicService.GetAllClinics());
    }
}
