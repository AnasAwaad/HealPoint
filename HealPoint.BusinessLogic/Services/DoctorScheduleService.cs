using HealPoint.BusinessLogic.Contracts;

namespace HealPoint.BusinessLogic.Services;
internal class DoctorScheduleService : IDoctorScheduleService
{
	public IEnumerable<DoctorScheduleDetailsDto> GetDoctorDaySchedule(string userId, DayOfWeek dayOfWeek)
	{
		throw new NotImplementedException();
	}
}
