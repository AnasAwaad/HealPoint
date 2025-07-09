namespace HealPoint.DataAccess.Contracts;
public interface IDoctorRepository : IRepository<Doctor>
{
	IQueryable<Doctor> GetAllWithDetails();
	IQueryable<Doctor> GetAllWithSchedulesAndDetails();
	Doctor? GetDoctorByContactEmail(string email);
	Doctor? GetDoctorByEmergencyContactPhone(string emergencyContactNumber);
	Doctor? GetDoctorByIdWithDetails(int id);
	Doctor? GetByIdWithUser(int id);
	Doctor? GetDoctorByUserId(string userId);
	Doctor? GetDoctorWithSymptomsByUserId(string userId);
	Doctor? GetDoctorWithSymptomsByDoctorId(int id);
}
