namespace HealPoint.BusinessLogic.Contracts;
public interface IDoctorService
{
	IEnumerable<DoctorDto> GetAll();

	//Task CreateAsync(DoctorCreateDto dto);
}
