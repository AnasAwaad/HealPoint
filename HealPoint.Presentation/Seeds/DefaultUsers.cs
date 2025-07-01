using HealPoint.DataAccess.Consts;
using Microsoft.AspNetCore.Identity;

namespace HealPoint.Presentation.Seeds;

public static class DefaultUsers
{
	public static async Task SeedUsers(UserManager<ApplicationUser> userManager)
	{
		var admin = new ApplicationUser
		{
			FirstName = "Admin",
			UserName = "Admin",
			Email = "Admin@gmail.com",
			EmailConfirmed = true,
			IsDeleted = false,
		};

		var doctor = new ApplicationUser
		{
			FirstName = "Doctor",
			UserName = "Doctor",
			Email = "Doctor@gmail.com",
			EmailConfirmed = true,
			IsDeleted = false,
		};

		var adminUser = await userManager.FindByNameAsync(admin.UserName);
		var doctorUser = await userManager.FindByNameAsync(doctor.UserName);

		if (adminUser is null)
		{
			await userManager.CreateAsync(admin, "Admin@Anas123");
			await userManager.AddToRoleAsync(admin, AppRoles.Admin);
		}

		if (doctorUser is null)
		{
			await userManager.CreateAsync(doctor, "123");
			await userManager.AddToRoleAsync(doctor, AppRoles.Doctor);
		}
	}
}
