using HealPoint.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HealPoint.Presentation.Controllers;

[Authorize]
public class HomeController : Controller
{
	#region Props
	private readonly ILogger<HomeController> _logger;

	#endregion

	#region Ctor
	public HomeController(ILogger<HomeController> logger)
	{
		_logger = logger;
	}
	#endregion

	#region Actions
	public IActionResult Index()
	{
		return View();
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
