﻿using HealPoint.DataAccess.Consts;
using System.ComponentModel.DataAnnotations;

namespace HealPoint.BusinessLogic.DTOs;
public class UserResetPasswordDto
{
	public string Id { get; set; }


	[StringLength(100, MinimumLength = 6, ErrorMessage = Errors.MinMaxLength)]
	[DataType(DataType.Password)]
	[RegularExpression(RegexPattern.Password, ErrorMessage = Errors.WeakPassword)]
	public string Password { get; set; } = null!;

	[DataType(DataType.Password)]
	[Display(Name = "Confirm password")]
	[Compare("Password", ErrorMessage = Errors.PasswordConfirmed)]
	public string ConfirmPassword { get; set; } = null!;
}
