using HealPoint.BusinessLogic.DTOs;
using HealPoint.BusinessLogic.DTOs.Doctor;

namespace HealPoint.Presentation.ViewModels;

public class HomeViewModel
{
	public IEnumerable<ServiceDto> Services { get; set; }
	public IEnumerable<SpecializationDto> Specializations { get; set; }
	public IEnumerable<SymptomDto> Symptoms { get; set; }
	public IEnumerable<DoctorCardDto> InpersonDoctors { get; set; }
	public IEnumerable<DoctorCardDto> TelehealthDoctors { get; set; }
}
