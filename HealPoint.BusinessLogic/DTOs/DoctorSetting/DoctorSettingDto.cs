namespace HealPoint.BusinessLogic.DTOs;
public class DoctorSettingDto
{
	public int DoctorId { get; set; }
	public IEnumerable<DoctorServiceItemDto> AvailableServices { get; set; }
	public int? SelectedServiceId { get; set; }
}
