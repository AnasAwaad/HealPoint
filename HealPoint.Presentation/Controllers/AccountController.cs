using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HealPoint.Presentation.Controllers;
public class AccountController : Controller
{
	private readonly IAuthService _authService;

	public AccountController(IAuthService authService)
	{
		_authService = authService;
	}

	public IActionResult Register() => View();

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Register(RegisterPatientDto model)
	{

		if (!ModelState.IsValid)
			return View(model);

		var result = await _authService.RegisterPatientAsync(model);
		if (result.Succeeded)
		{
			var confirmationUrl = Url.Page(
				"/Account/RegisterConfirmation",
				pageHandler: null,
				values: new { area = "Identity", email = model.Email },
				protocol: Request.Scheme);

			return Redirect(confirmationUrl);
		}

		foreach (var error in result.Errors)
			ModelState.AddModelError(string.Empty, error.Description);

		return View(model);
	}
}
