namespace HealPoint.DataAccess.Consts;
public static class Errors
{
	public const string MaxLengthExceeded = "The maximum length for this field is {0} characters.";
	public const string Dublicated = "{0} with the same name is already exists!";
	public const string OnlyEnglishLetters = "Only English letters are allowed.";
	public const string PhoneNumberNotAllowed = "The provided phone number is not valid.";
	public const string AllowUsername = "Username must start with a letter and be 3 to 20 characters long. Only letters, numbers, underscores, hyphens, @, and # are allowed.";
	public const string MinMaxLength = "The {0} must be at least {2} and at max {1} characters long.";
	public const string WeakPassword = "Your password must be at least 6 characters long and include at least one uppercase letter, one lowercase letter, one number, and one special character (e.g., @, $, !). Please update your password to meet these requirements.";

}
