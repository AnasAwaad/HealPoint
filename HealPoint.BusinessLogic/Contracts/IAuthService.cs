using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Contracts;
public interface IAuthService
{
	Task<ApplicationUser?> GetUsersByIdAsync(string id);
	Task<(bool isSucceeded, string? errors)> ResetPasswordAsync(string userId, string password);
}
