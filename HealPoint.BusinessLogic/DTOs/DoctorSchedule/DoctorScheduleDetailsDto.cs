namespace HealPoint.BusinessLogic.DTOs;
public class DoctorScheduleDetailsDto
{
	public int Id { get; set; }
	public string DayOfWeek { get; set; }
	public string StartTime { get; set; }
	public string EndTime { get; set; }
}
