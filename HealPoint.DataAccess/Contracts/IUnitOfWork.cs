namespace HealPoint.DataAccess.Contracts;
public interface IUnitOfWork : IDisposable
{
	IDepartmentRepository Departments { get; }
	IClinicRepository Clinics { get; }
	IClinicSessionRepository ClinicSessions { get; }
	ISpecializationRepository Specializations { get; }
	IDoctorRepository Doctors { get; }
	ITimeSlotRepository TimeSlots { get; }

	void SaveChanges();
}
