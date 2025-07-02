namespace HealPoint.BusinessLogic.DTOs;
public class DoctorScheduleDetailsDto
{
	public int? Id { get; set; }
	public string DayOfWeek { get; set; }
	public TimeSpan StartTime { get; set; }
	public TimeSpan EndTime { get; set; }
}
