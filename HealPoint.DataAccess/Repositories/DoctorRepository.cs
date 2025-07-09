using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Data;

namespace HealPoint.DataAccess.Repositories;
internal class DoctorRepository : Repository<Doctor>, IDoctorRepository
{
	public DoctorRepository(ApplicationDbContext context) : base(context)
	{
	}

	public IQueryable<Doctor> GetAllWithDetails()
	{
		return _context.Doctors
			.Include(d => d.Specialization)
			.Include(d => d.ApplicationUser);
	}

	public Doctor? GetDoctorByIdWithDetails(int id)
	{
		return _context.Doctors
			.Include(d => d.Specialization)
			.Include(d => d.ApplicationUser)
			.FirstOrDefault(d => !d.IsDeleted && d.Id == id);
	}
	public Doctor? GetByIdWithUser(int id)
	{
		return _context.Doctors
			.Include(d => d.ApplicationUser)
			.FirstOrDefault(d => d.Id == id);

	}
	public Doctor? GetDoctorByContactEmail(string email)
	{
		return _context.Doctors.Where(d => d.ContactEmail == email).FirstOrDefault();
	}

	public Doctor? GetDoctorByEmergencyContactPhone(string emergencyContactNumber)
	{
		return _context.Doctors.Where(d => d.EmergencyContactPhone == emergencyContactNumber).FirstOrDefault();
	}

	public Doctor? GetDoctorByUserId(string userId)
	{
		return _context.Doctors
			.FirstOrDefault(d => d.ApplicationUserId == userId && !d.IsDeleted);
	}

	public Doctor? GetDoctorWithSymptomsByUserId(string userId)
	{
		return _context.Doctors
			.Include(d => d.Symptoms)
			.FirstOrDefault(d => d.ApplicationUserId == userId && !d.IsDeleted);
	}

	public Doctor? GetDoctorWithSymptomsByDoctorId(int id)
	{
		return _context.Doctors
			.Include(d => d.Symptoms)
			.FirstOrDefault(d => d.Id == id && !d.IsDeleted);
	}

	public IEnumerable<Doctor> GetAllWithSchedulesAndDetails()
	{
		return _context.Doctors
			.Include(d => d.ApplicationUser)
			.Include(d => d.Specialization)
			.Include(d => d.Schedules)
				.ThenInclude(s => s.DoctorScheduleDetails)
			.Where(d => !d.IsDeleted)
			.AsEnumerable();
	}
}
