namespace HealPoint.DataAccess.Contracts;
public interface IUnitOfWork : IDisposable
{
	IDepartmentRepository Departments { get; }
	IClinicRepository Clinics { get; }
	IClinicSessionRepository ClinicSessions { get; }
	ISpecializationRepository Specializations { get; }
	IDoctorRepository Doctors { get; }
	IDoctorScheduleRepository DoctorSchedules { get; }
	IServiceRepository Services { get; }
	ISymptomRepository Symptoms { get; }
	IPatientRepository Patients { get; }

	void SaveChanges();
}
