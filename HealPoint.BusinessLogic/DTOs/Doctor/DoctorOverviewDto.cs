using HealPoint.BusinessLogic.DTOs.DoctorSchedule;

namespace HealPoint.BusinessLogic.DTOs.Doctor;
public class DoctorOverviewDto
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Specialization { get; set; }
	public string ProfilePhotoUrl { get; set; }
	public List<DoctorOverviewScheduleDto> Schedules { get; set; } = new List<DoctorOverviewScheduleDto>();


}
