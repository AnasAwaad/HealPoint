namespace HealPoint.BusinessLogic.DTOs.DoctorSchedule;
public class DoctorOverviewScheduleDetailDto
{
	public DayOfWeek DayOfWeek { get; set; }
	public TimeSpan StartTime { get; set; }
	public TimeSpan EndTime { get; set; }
}
