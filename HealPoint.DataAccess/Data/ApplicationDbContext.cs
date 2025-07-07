using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HealPoint.DataAccess.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{

	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
	}


	public DbSet<Department> Departments { get; set; }
	public DbSet<Clinic> Clinics { get; set; }
	public DbSet<ClinicSession> ClinicSessions { get; set; }
	public DbSet<Doctor> Doctors { get; set; }
	public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
	public DbSet<DoctorScheduleDetails> DoctorScheduleDetails { get; set; }
	public DbSet<Specialization> Specializations { get; set; }
	public DbSet<Service> Services { get; set; }
	public DbSet<Symptom> Symptoms { get; set; }
	public DbSet<DoctorSymptom> DoctorSymptoms { get; set; }
	public DbSet<Patient> Patients { get; set; }

}