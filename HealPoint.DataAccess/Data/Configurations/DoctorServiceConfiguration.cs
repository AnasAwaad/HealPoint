namespace HealPoint.DataAccess.Data.Configurations;

internal class DoctorServiceConfiguration : IEntityTypeConfiguration<DoctorService>
{
	public void Configure(EntityTypeBuilder<DoctorService> builder)
	{

		builder.HasKey(ds => new { ds.DoctorId, ds.ServiceId });

		// Configure the relationship with Service and Doctor

		builder.HasOne(ds => ds.Service)
			.WithMany(s => s.DoctorServices)
			.HasForeignKey(ds => ds.ServiceId)
			.OnDelete(DeleteBehavior.Cascade);



		builder.HasOne(ds => ds.Doctor)
			.WithMany(d => d.DoctorServices)
			.HasForeignKey(ds => ds.DoctorId)
			.OnDelete(DeleteBehavior.Cascade);

	}

}
