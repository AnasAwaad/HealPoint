using HealPoint.DataAccess.Consts;
using System.ComponentModel.DataAnnotations;

namespace HealPoint.BusinessLogic.DTOs;
public class RegisterPatientDto
{
	[MaxLength(150, ErrorMessage = Errors.MaxLengthExceeded)]
	[EmailAddress]
	public string Email { get; set; }

	[StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = Errors.MinMaxLength), DataType(DataType.Password)]
	[RegularExpression(RegexPattern.Password, ErrorMessage = Errors.WeakPassword)]
	public string? Password { get; set; } = null!;


	[Display(Name = "Confirm Password")]
	[Compare("Password", ErrorMessage = Errors.PasswordConfirmed)]
	public string ConfirmPassword { get; set; } = null!;
}
