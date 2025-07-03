using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Data;

namespace HealPoint.DataAccess.Repositories;
internal class DoctorScheduleRepository : Repository<DoctorSchedule>, IDoctorScheduleRepository
{
	public DoctorScheduleRepository(ApplicationDbContext context) : base(context)
	{
	}

	public DoctorSchedule? GetDoctorScheduleWithDetails(int doctorId)
	{
		return _context.DoctorSchedules
			.Where(s => s.DoctorId == doctorId && !s.IsDeleted)
			.Include(s => s.DoctorScheduleDetails)
			.FirstOrDefault();
	}
}
