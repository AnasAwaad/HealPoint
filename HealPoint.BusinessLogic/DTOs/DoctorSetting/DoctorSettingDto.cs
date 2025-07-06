using HealPoint.BusinessLogic.DTOs.Specialization;

namespace HealPoint.BusinessLogic.DTOs;
public class DoctorSettingDto
{
	public int DoctorId { get; set; }
	public IEnumerable<DoctorServiceItemDto> AvailableServices { get; set; }
	public IEnumerable<DoctorSpecializationItemDto> Specializations { get; set; }
	public int? SelectedServiceId { get; set; }
	public int? SelectedSpecializationId { get; set; }
}
