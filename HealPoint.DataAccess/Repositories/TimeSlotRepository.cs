using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Data;

namespace HealPoint.DataAccess.Repositories;
internal class TimeSlotRepository : Repository<TimeSlot>, ITimeSlotRepository
{
	public TimeSlotRepository(ApplicationDbContext context) : base(context)
	{
	}

	public IEnumerable<TimeSlot> GetByDayAndDoctorIdAsync(int doctorId, DayOfWeek day)
	{
		return _context.TimeSlots
			.Where(t => t.DoctorId == doctorId && t.DayOfWeek == day)
			.OrderBy(t => t.StartTime)
			.AsEnumerable();
	}
}
