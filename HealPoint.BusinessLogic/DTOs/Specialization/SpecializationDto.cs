﻿namespace HealPoint.BusinessLogic.DTOs;
public class SpecializationDto
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
	public string CategoryName { get; set; } = null!;
	public bool Status { get; set; }

}
