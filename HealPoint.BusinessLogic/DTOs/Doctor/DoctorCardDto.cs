﻿using HealPoint.DataAccess.Enums;

namespace HealPoint.BusinessLogic.DTOs;
public class DoctorCardDto
{
	public int Id { get; set; }
	public string FullName { get; set; }
	public string Description { get; set; }
	public string Specialization { get; set; }
	public string ProfilePhotoUrl { get; set; }
	public string ClinicAddress { get; set; }
	public DoctorOperationMode OperationMode { get; set; }
	public float Rating { get; set; }
	public int TotalReviews { get; set; }
	public bool AvailableToday { get; set; }
	public decimal Price { get; set; }
	public List<string> AvailableTimes { get; set; }
	public List<DoctorScheduleDto> Schedules { get; set; } = new();

}
