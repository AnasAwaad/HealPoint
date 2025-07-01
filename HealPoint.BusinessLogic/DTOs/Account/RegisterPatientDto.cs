using HealPoint.DataAccess.Consts;
using System.ComponentModel.DataAnnotations;

namespace HealPoint.BusinessLogic.DTOs;
public class RegisterPatientDto
{
	[Display(Name = "First Name")]
	[MaxLength(100, ErrorMessage = Errors.MaxLengthExceeded)]
	[RegularExpression(RegexPattern.CharactersOnly_Eng, ErrorMessage = Errors.OnlyEnglishLetters)]
	public string FirstName { get; set; } = null!;

	[Display(Name = "Last Name")]
	[MaxLength(100, ErrorMessage = Errors.MaxLengthExceeded)]
	[RegularExpression(RegexPattern.CharactersOnly_Eng, ErrorMessage = Errors.OnlyEnglishLetters)]
	public string LastName { get; set; } = null!;

	[MaxLength(150, ErrorMessage = Errors.MaxLengthExceeded)]
	[EmailAddress]
	public string Email { get; set; } = null!;

	[StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = Errors.MinMaxLength), DataType(DataType.Password)]
	[RegularExpression(RegexPattern.Password, ErrorMessage = Errors.WeakPassword)]
	public string Password { get; set; } = null!;


	[Display(Name = "Confirm Password")]
	[Compare("Password", ErrorMessage = Errors.PasswordConfirmed)]
	public string ConfirmPassword { get; set; } = null!;
}
