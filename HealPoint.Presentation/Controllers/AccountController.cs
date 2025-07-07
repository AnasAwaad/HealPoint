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

	public IActionResult Login() => View();


	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Login(LoginDto model, string? returnUrl)
	{
		if (!ModelState.IsValid)
			return View(model);

		var (result, role) = await _authService.LoginAsync(model);

		if (result.Succeeded)
		{
			if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
				return Redirect(returnUrl);

			return role switch
			{
				"Patient" => RedirectToAction("Index", "Home"),
				"Doctor" => RedirectToAction("Create", "DoctorSchedules"),
				"Admin" => RedirectToAction("Index", "Doctors"),
				_ => RedirectToAction("Index", "Home")
			};
		}
		if (result.IsNotAllowed)
		{
			ModelState.AddModelError(string.Empty, "Please confirm your email first.");
			return View(model);
		}
		else
		{
			ModelState.AddModelError(string.Empty, $"Invalid login attempt.");
			return View(model);
		}
	}
}
