namespace HealPoint.DataAccess.Contracts;
public interface ITimeSlotRepository : IRepository<TimeSlot>
{
	IEnumerable<TimeSlot> GetByDayAndDoctorIdAsync(int doctorId, DayOfWeek day);
}
