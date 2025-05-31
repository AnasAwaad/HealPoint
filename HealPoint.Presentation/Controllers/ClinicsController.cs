using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.Presentation.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HealPoint.Presentation.Controllers;
public class ClinicsController : Controller
{
    private readonly IClinicService _clinicService;
    private readonly ISpecializationService _specializationService;

    public ClinicsController(IClinicService clinicService, ISpecializationService specializationService)
    {
        _clinicService = clinicService;
        _specializationService = specializationService;
    }

    public IActionResult Index()
    {
        return View(_clinicService.GetAllClinics());
    }


    public IActionResult Create()
    {
        var model = new CreateClinicDto
        {
            SpecializationOptions = _specializationService.GetSpecializationSelectList()
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreateClinicDto clinic)
    {
        if (!ModelState.IsValid)
        {
            var model = new CreateClinicDto
            {
                SpecializationOptions = _specializationService.GetSpecializationSelectList()
            };
            return View(model);
        }

        _clinicService.CreateClinic(clinic);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Update(int id)
    {

        var clinic = _clinicService.GetClinicById(id);

        if (clinic is null)
            return NotFound();

        clinic.SpecializationOptions = _specializationService.GetSpecializationSelectList();

        return View(clinic);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(UpdateClinicDto clinic)
    {
        if (!ModelState.IsValid)
        {
            clinic.SpecializationOptions = _specializationService.GetSpecializationSelectList();
            return View(clinic);
        }

        _clinicService.UpdateClinic(clinic);

        return RedirectToAction(nameof(Index));
    }

    [AjaxOnly]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteClinic(int id)
    {
        var isDeleted = _clinicService.DeleteClinic(id);

        if (!isDeleted)
            return BadRequest();

        return Ok();
    }
}
