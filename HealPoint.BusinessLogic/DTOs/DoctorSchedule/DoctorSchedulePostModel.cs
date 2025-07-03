namespace HealPoint.BusinessLogic.DTOs;
public class DoctorSchedulePostModel
{
	public DoctorScheduleDto DoctorSchedule { get; set; }
	public List<DoctorScheduleDetailsDto> DoctorScheduleDetails { get; set; }
}
