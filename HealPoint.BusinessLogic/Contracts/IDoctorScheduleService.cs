namespace HealPoint.BusinessLogic.Contracts;
public interface IDoctorScheduleService
{
	IEnumerable<DoctorScheduleDetailsDto> GetDoctorDaySchedule(string userId, DayOfWeek dayOfWeek);
}
