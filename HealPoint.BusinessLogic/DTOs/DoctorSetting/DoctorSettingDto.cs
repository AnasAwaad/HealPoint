namespace HealPoint.BusinessLogic.DTOs;
public class DoctorSettingDto
{
	public IEnumerable<DoctorServiceItemDto> AvailableServices { get; set; }
	public int? SelectedServiceId { get; set; }
}
