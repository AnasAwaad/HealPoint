using HealPoint.DataAccess.Enums;

namespace HealPoint.BusinessLogic.DTOs;
public class DoctorDetailsDto
{
	public int Id { get; set; }
	public string FullName { get; set; }
	public string ProfilePhotoPath { get; set; }
	public string SpecializationName { get; set; }
	public string Description { get; set; }
	public DoctorOperationMode OperationMode { get; set; }

	//public Dictionary<DateTime, List<string>> AvailableTimesByDay { get; set; }
}
