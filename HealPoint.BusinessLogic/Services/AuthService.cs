using HealPoint.BusinessLogic.Contracts;
using HealPoint.DataAccess.Consts;
using HealPoint.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace HealPoint.BusinessLogic.Services;
internal class AuthService(UserManager<ApplicationUser> userManager) : IAuthService
{
	public async Task<ApplicationUser?> GetUsersByIdAsync(string id)
	{
		return await userManager.FindByIdAsync(id);
	}

	public async Task<IdentityResult> RegisterPatientAsync(RegisterPatientDto dto)
	{
		var user = new ApplicationUser()
		{
			FirstName = dto.FirstName,
			LastName = dto.LastName,
			Email = dto.Email,
			UserName = dto.Email,
		};

		var userResult = await userManager.CreateAsync(user, dto.Password);

		if (!userResult.Succeeded)
			return userResult;

		var result = await userManager.AddToRoleAsync(user, AppRoles.Patient);

		return result;
	}

	public async Task<(bool isSucceeded, string? errors)> ResetPasswordAsync(string userId, string password)
	{
		var user = await userManager.FindByIdAsync(userId);

		if (user is null)
			return (false, "User not found");

		var passwordHash = user.PasswordHash;
		await userManager.RemovePasswordAsync(user);

		var result = await userManager.AddPasswordAsync(user, password);

		if (!result.Succeeded)
		{

			user.PasswordHash = passwordHash;
			await userManager.UpdateAsync(user);

			return (false, string.Join(", ", result.Errors.Select(err => err.Description)));
		}

		user.LastUpdatedOn = DateTime.Now;
		await userManager.UpdateAsync(user);

		return (true, null);

	}
}
