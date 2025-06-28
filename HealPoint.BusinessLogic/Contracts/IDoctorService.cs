namespace HealPoint.BusinessLogic.Contracts;
public interface IDoctorService
{
	IEnumerable<DoctorDto> GetAll();
	DoctorFormDto? GetById(int id);
	Task CreateAsync(DoctorFormDto dto);
	bool IsAllowedMobileNumber(string phoneNumber, int? id);
	bool IsAllowedContactEmail(string phoneNumber, int? id);
	bool IsAllowedEmergencyContactPhone(string emergencyContactPhone, int? id);
	bool IsAllowedUserName(string userName, int? id);
	bool IsAllowedEmail(string email, int? id);
}
