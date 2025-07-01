namespace HealPoint.DataAccess.Entities;
public class TimeSlot : BaseEntity
{
	public int Id { get; set; }
	public DayOfWeek DayOfWeek { get; set; }
	public TimeOnly StartTime { get; set; }
	public TimeOnly EndTime { get; set; }
	public int DoctorId { get; set; }
	public Doctor Doctor { get; set; }

}
