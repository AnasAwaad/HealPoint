// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace HealPoint.Presentation.Areas.Identity.Pages.Account
{
	[AllowAnonymous]
	public class RegisterConfirmationModel : PageModel
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IEmailSender _sender;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public RegisterConfirmationModel(UserManager<ApplicationUser> userManager, IEmailSender sender, IWebHostEnvironment webHostEnvironment)
		{
			_userManager = userManager;
			_sender = sender;
			_webHostEnvironment = webHostEnvironment;
		}

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public string FirstName { get; set; }
		public string Email { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public bool DisplayConfirmAccountLink { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public string EmailConfirmationUrl { get; set; }

		public async Task<IActionResult> OnGetAsync(string email, string returnUrl = null)
		{
			if (email == null)
			{
				return RedirectToPage("/Index");
			}
			returnUrl = returnUrl ?? Url.Content("~/");

			var user = await _userManager.FindByEmailAsync(email);

			if (user == null)
			{
				return NotFound($"Unable to load user with email '{email}'.");
			}
			FirstName = user.FirstName;
			Email = email;
			// Once you add a real email sender, you should remove this code that lets you confirm the account
			DisplayConfirmAccountLink = true;
			if (DisplayConfirmAccountLink)
			{
				var userId = await _userManager.GetUserIdAsync(user);

				//Send email activation to the new patient

				string activationLink = await GenerateActivationLinkAsync(user);

				var emailBody = PrepareEmailBody(user, activationLink);

				await _sender.SendEmailAsync(user.Email, "Confirm your email", emailBody);
			}

			return Page();
		}

		private string PrepareEmailBody(ApplicationUser user, string activationLink)
		{
			var templatePath = $"{_webHostEnvironment.WebRootPath}/templates/patient-confirm-email.html";
			StreamReader stream = new(templatePath);

			var body = stream.ReadToEnd();
			stream.Close();

			body = body
				.Replace("[patientName]", $"{user.FirstName} {user.LastName}")
				.Replace("[activationLink]", activationLink)
				.Replace("[year]", DateTime.Now.Year.ToString());

			return body;
		}

		private async Task<string> GenerateActivationLinkAsync(ApplicationUser user)
		{
			var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
			code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
			var callbackUrl = Url.Page(
				"/Account/ConfirmEmail",
				pageHandler: null,
				values: new { area = "Identity", userId = user.Id, code = code },
				protocol: Request.Scheme);


			return callbackUrl;
		}
	}
}
