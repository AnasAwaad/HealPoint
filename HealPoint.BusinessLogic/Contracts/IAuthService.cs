using HealPoint.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace HealPoint.BusinessLogic.Contracts;
public interface IAuthService
{
	Task<ApplicationUser?> GetUsersByIdAsync(string id);
	Task<IdentityResult> RegisterPatientAsync(RegisterPatientDto dto);
	Task<(bool isSucceeded, string? errors)> ResetPasswordAsync(string userId, string password);
}
