namespace HealPoint.DataAccess.Data.Configurations;
internal class ClinicSessionConfiguration : BaseEntityConfiguration<ClinicSession>, IEntityTypeConfiguration<ClinicSession>
{
	public void Configure(EntityTypeBuilder<ClinicSession> builder)
	{
		base.Configure(builder);

		builder.HasKey(cs => cs.Id);

		builder.Property(cs => cs.DayOfWeek)
			   .IsRequired();

		builder.Property(cs => cs.StartTime)
			   .IsRequired();

		builder.Property(cs => cs.EndTime)
			   .IsRequired();


		// Add relation with Clinic
		builder.HasOne(cs => cs.Clinic)
			   .WithMany(c => c.Sessions)
			   .HasForeignKey(cs => cs.ClinicId)
			   .OnDelete(DeleteBehavior.Cascade);
	}
}
