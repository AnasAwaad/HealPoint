using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.Presentation.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HealPoint.Presentation.Controllers;
public class SpecializationsController : Controller
{
    private readonly ISpecializationService _specializationService;

    public SpecializationsController(ISpecializationService specializationService)
    {
        _specializationService = specializationService;
    }

    public IActionResult Index()
    {
        return View(_specializationService.GetAllSpecializations());
    }

    [AjaxOnly]
    public IActionResult Create()
    {
        var specDto = new SpecializationFormDto
        {
            CategoryOptions = _specializationService.GetCategorySelectList()
        };
        return PartialView("_Form", specDto);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(SpecializationFormDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var spec = _specializationService.CreateSpecialization(model);

        return PartialView("_SpecializationRow", spec);
    }

    [AjaxOnly]
    public IActionResult Update(int id)
    {
        var specialization = _specializationService.GetSpecializationById(id);

        if (specialization is null)
            return NotFound();

        specialization.CategoryOptions = _specializationService.GetCategorySelectList();

        return PartialView("_Form", specialization);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(SpecializationFormDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var specializationDto = _specializationService.UpdateSpecialization(model);

        if (specializationDto == null)
            return NotFound();

        return PartialView("_SpecializationRow", specializationDto);
    }

    public IActionResult AllowedSpecializationName(SpecializationFormDto model)
    {
        return Json(_specializationService.IsSpecializationAllowed(model));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ChangeSpecializationStatus(int id)
    {
        var lastUpdatedOn = _specializationService.UpdateSpecializationStatus(id);

        if (lastUpdatedOn is null)
            return NotFound();

        return Ok(lastUpdatedOn);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteSpecialization(int id)
    {
        var isDeleted = _specializationService.DeleteSpecialization(id);

        if (!isDeleted)
            return BadRequest();

        return Ok();
    }
}
