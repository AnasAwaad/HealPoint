namespace HealPoint.DataAccess.Contracts;
public interface IDoctorScheduleRepository : IRepository<DoctorSchedule>
{
	DoctorSchedule? GetDoctorScheduleWithDetails(int doctorId);
}
