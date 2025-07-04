using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Repositories;

namespace HealPoint.DataAccess.Data;
internal class UnitOfWork : IUnitOfWork
{
	private readonly ApplicationDbContext _context;

	private readonly Lazy<ISpecializationRepository> _specializationRepository;
	private readonly Lazy<IDepartmentRepository> _departmentRepository;
	private readonly Lazy<IClinicRepository> _clinicRepository;
	private readonly Lazy<IClinicSessionRepository> _clinicSessionRepository;
	private readonly Lazy<IDoctorRepository> _doctorRepository;
	private readonly Lazy<IDoctorScheduleRepository> _doctorScheduleRepository;
	private readonly Lazy<IServiceRepository> _serviceRepository;

	public UnitOfWork(ApplicationDbContext context)
	{
		_context = context;

		_specializationRepository = new Lazy<ISpecializationRepository>(new SpecializationRepository(_context));
		_departmentRepository = new Lazy<IDepartmentRepository>(new DepartmentRepository(_context));
		_clinicRepository = new Lazy<IClinicRepository>(new ClinicRepository(_context));
		_clinicSessionRepository = new Lazy<IClinicSessionRepository>(new ClinicSessionRepository(_context));
		_doctorRepository = new Lazy<IDoctorRepository>(new DoctorRepository(_context));
		_doctorScheduleRepository = new Lazy<IDoctorScheduleRepository>(new DoctorScheduleRepository(_context));
		_serviceRepository = new Lazy<IServiceRepository>(new ServiceRepository(_context));
	}

	public ISpecializationRepository Specializations => _specializationRepository.Value;
	public IDepartmentRepository Departments => _departmentRepository.Value;
	public IClinicRepository Clinics => _clinicRepository.Value;
	public IClinicSessionRepository ClinicSessions => _clinicSessionRepository.Value;
	public IDoctorRepository Doctors => _doctorRepository.Value;
	public IDoctorScheduleRepository DoctorSchedules => _doctorScheduleRepository.Value;
	public IServiceRepository Services => _serviceRepository.Value;

	public void SaveChanges()
	{
		_context.SaveChanges();
	}
	public void Dispose()
	{
		_context.Dispose();
	}
}