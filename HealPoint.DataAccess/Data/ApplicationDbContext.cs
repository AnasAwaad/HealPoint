﻿namespace HealPoint.DataAccess.Data;
internal class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{

	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
	}


	public DbSet<Category> Categories { get; set; }
	public DbSet<Clinic> Clinics { get; set; }
	public DbSet<ClinicSession> ClinicSessions { get; set; }
	public DbSet<Specialization> Specializations { get; set; }

}