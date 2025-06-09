using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HealPoint.Presentation.Controllers;
public class ClinicSessionsController : Controller
{
    private readonly IClinicSessionService _clinicSessionService;

    public ClinicSessionsController(IClinicSessionService clinicSessionService)
    {
        _clinicSessionService = clinicSessionService;
    }

    public IActionResult Index(int clinicId)
    {
        return View(_clinicSessionService.GetSessionsByClinicId(clinicId));
    }

    [HttpPost]
    public IActionResult SaveClinicSessions([FromBody] List<ClinicSessionDto> clinicSessions)
    {
        if (clinicSessions == null || !clinicSessions.Any())
        {
            return BadRequest("No clinic sessions data received.");
        }

        _clinicSessionService.SaveClinicSessions(clinicSessions);
        return Ok();
    }
}
