
using HealPoint.BusinessLogic.DTO;
using HealPoint.BusinessLogic.DTOs.Specialization;

namespace HealPoint.BusinessLogic.DTOs;
public class DoctorSettingDto
{
	public int DoctorId { get; set; }
	public IEnumerable<DoctorServiceItemDto> AvailableServices { get; set; } = new List<DoctorServiceItemDto>();
	public IEnumerable<DoctorSpecializationItemDto> Specializations { get; set; } = new List<DoctorSpecializationItemDto>();
	public IEnumerable<DoctorSymptomItemDto> Symptoms { get; set; } = new List<DoctorSymptomItemDto>();
	public IList<int> SelectedSymptoms { get; set; } = new List<int>();
	public int? SelectedServiceId { get; set; }
	public int? SelectedSpecializationId { get; set; }
}
