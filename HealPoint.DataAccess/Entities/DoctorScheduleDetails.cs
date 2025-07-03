namespace HealPoint.DataAccess.Entities;
public class DoctorScheduleDetails : BaseEntity
{
	public int DoctorScheduleId { get; set; }
	public DoctorSchedule DoctorSchedule { get; set; }
	public DayOfWeek DayOfWeek { get; set; }
	public TimeSpan StartTime { get; set; }
	public TimeSpan EndTime { get; set; }
}
