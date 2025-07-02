namespace HealPoint.BusinessLogic.Contracts;
public interface IDoctorScheduleService
{
	//IEnumerable<DoctorScheduleDetailsDto> GetDoctorDaySchedule(string userId, DayOfWeek dayOfWeek);
	void Create(DoctorScheduleDto doctorScheduleDto, string userId);
	DoctorScheduleDto GetAllWithDetails(string value);
}
