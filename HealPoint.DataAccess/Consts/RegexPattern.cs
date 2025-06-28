﻿namespace HealPoint.DataAccess.Consts;
public static class RegexPattern
{
	public const string PhoneNumber = "^01[0-2,5]{1}[0-9]{8}$";
	public const string Password = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{6,}$";
	public const string Username = "^[a-zA-Z][a-zA-Z0-9-._@#]{2,19}$";
	public const string CharactersOnly_Eng = "^[a-zA-Z-_ ]*$";
	public const string CharactersOnly_Ar = "^[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FF ]*$";
	public const string NumbersAndChrOnly_ArEng = "^(?=.*[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z])[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z0-9 _-]+$";


}
