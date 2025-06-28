namespace HealPoint.BusinessLogic.Contracts;
public interface IDoctorService
{
	IEnumerable<DoctorDto> GetAll();

	Task CreateAsync(CreateDoctorDto dto);
	bool IsAllowedMobileNumber(string phoneNumber, int id);
	bool IsAllowedContactEmail(string phoneNumber, int id);
	bool IsAllowedEmergencyContactPhone(string emergencyContactPhone, int id);
	bool IsAllowedUserName(string userName, int id);
	bool IsAllowedEmail(string email, int id);
}
