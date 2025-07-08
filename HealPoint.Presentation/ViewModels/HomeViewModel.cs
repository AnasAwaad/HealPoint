using HealPoint.BusinessLogic.DTOs;

namespace HealPoint.Presentation.ViewModels;

public class HomeViewModel
{
	public IEnumerable<ServiceDto> Services { get; set; }
	public IEnumerable<SpecializationDto> Specializations { get; set; }
	public IEnumerable<SymptomDto> Symptoms { get; set; }
}
