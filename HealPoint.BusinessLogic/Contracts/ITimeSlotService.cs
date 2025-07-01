namespace HealPoint.BusinessLogic.Contracts;
public interface ITimeSlotService
{
	IEnumerable<TimeSlotDto> GetTimeSlots(string userId, DayOfWeek day);
	TimeSlotDto CreateTimeSlot(TimeSlotDto dto, string userId);
}
