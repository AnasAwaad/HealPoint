namespace HealPoint.BusinessLogic.DTOs;
public class TimeSlotDto
{
	public int Id { get; set; }
	public TimeOnly StartTime { get; set; }
	public TimeOnly EndTime { get; set; }
	public string? DayOfWeek { get; set; }
	public bool IsValidTimeRange()
	{
		return StartTime < EndTime;
	}
}
