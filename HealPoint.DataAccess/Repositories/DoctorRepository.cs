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
			.Include(d => d.ApplicationUser)
			.Where(d => !d.IsDeleted);
	}

	public Doctor? GetDoctorByIdWithDetails(int id)
	{
		return _context.Doctors
			.Include(d => d.Specialization)
			.Include(d => d.ApplicationUser)
			.FirstOrDefault(d => !d.IsDeleted && d.Id == id);
	}

	public Doctor? GetDoctorByContactEmail(string email)
	{
		return _context.Doctors.Where(d => d.ContactEmail == email).FirstOrDefault();
	}

	public Doctor? GetDoctorByEmergencyContactPhone(string emergencyContactNumber)
	{
		return _context.Doctors.Where(d => d.EmergencyContactPhone == emergencyContactNumber).FirstOrDefault();
	}

}
