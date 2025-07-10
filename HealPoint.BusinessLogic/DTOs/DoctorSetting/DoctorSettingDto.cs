using HealPoint.DataAccess.Enums;

namespace HealPoint.BusinessLogic.DTOs;
public class DoctorSettingDto
{
	public int DoctorId { get; set; }
	public IEnumerable<ServiceDto> AvailableServices { get; set; } = new List<ServiceDto>();
	public IEnumerable<SpecializationDto> Specializations { get; set; } = new List<SpecializationDto>();
	public IEnumerable<SymptomDto> Symptoms { get; set; } = new List<SymptomDto>();
	public IList<int> SelectedSymptoms { get; set; } = new List<int>();
	public int? SelectedServiceId { get; set; }
	public int? SelectedSpecializationId { get; set; }
	public int? ServicePrice { get; set; }
	public int? ServiceDurationInMinutes { get; set; }
	public DoctorOperationMode OperationMode { get; set; }

}
