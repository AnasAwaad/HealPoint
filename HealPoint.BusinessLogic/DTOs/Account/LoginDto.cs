using HealPoint.DataAccess.Consts;
using System.ComponentModel.DataAnnotations;

namespace HealPoint.BusinessLogic.DTOs;
public class LoginDto
{
	[EmailAddress]
	[MaxLength(150, ErrorMessage = Errors.MaxLengthExceeded)]
	public string Email { get; set; } = null!;

	[StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = Errors.MinMaxLength), DataType(DataType.Password)]
	[RegularExpression(RegexPattern.Password, ErrorMessage = Errors.WeakPassword)]
	public string Password { get; set; } = null!;
}
