using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Contracts;
public interface IDoctorService
{
	IEnumerable<DoctorDto> GetAll();
	DoctorFormDto? GetById(int id);
	Doctor? GetWithSymptomsByUserId(string userId);
	Task CreateAsync(DoctorFormDto dto);
	bool IsAllowedMobileNumber(string phoneNumber, int? id);
	bool IsAllowedContactEmail(string phoneNumber, int? id);
	bool IsAllowedEmergencyContactPhone(string emergencyContactPhone, int? id);
	bool IsAllowedUserName(string userName, int? id);
	bool IsAllowedEmail(string email, int? id);
	Task UpdateAsync(DoctorFormDto dto);
	Task ToggleDoctorStatusAsync(int id);
	void ChangeService(int doctorId, int selectedServiceId);
	void ChangeSpecialization(int doctorId, int selectedSpecializationId);
	void UpdateSymptoms(int doctorId, IList<int> selectedSymptoms);
}
