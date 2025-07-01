namespace HealPoint.DataAccess.Data.Configurations;
internal class DoctorScheduleConfiguration : BaseEntityConfiguration<DoctorSchedule>, IEntityTypeConfiguration<DoctorSchedule>
{
	public void Configure(EntityTypeBuilder<DoctorSchedule> builder)
	{
		base.Configure(builder);

		builder.HasOne(ds => ds.Doctor)
			   .WithMany(d => d.Schedules)
			   .HasForeignKey(ds => ds.DoctorId)
			   .OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(ds => ds.Clinic)
				.WithMany()
			   .HasForeignKey(ds => ds.ClinicId)
			   .OnDelete(DeleteBehavior.Cascade);

		builder.HasMany(ds => ds.DoctorScheduleDetails)
			.WithOne()
			.HasForeignKey(ds => ds.DoctorScheduleId)
			.OnDelete(DeleteBehavior.NoAction);
	}
}
