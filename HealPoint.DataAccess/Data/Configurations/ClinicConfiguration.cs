namespace HealPoint.DataAccess.Data.Configurations;
internal class ClinicConfiguration : BaseEntityConfiguration<Clinic>, IEntityTypeConfiguration<Clinic>
{
	public void Configure(EntityTypeBuilder<Clinic> builder)
	{
		base.Configure(builder);

		builder.HasKey(c => c.Id);

		builder.Property(c => c.Name)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(c => c.Description)
			.HasMaxLength(500);

		builder.Property(c => c.ImagePath)
			.HasMaxLength(255);

		builder.Property(c => c.Email)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(c => c.ContactNumber)
			.IsRequired()
			.HasMaxLength(20);

		builder.Property(c => c.SpecializationId);



		builder.Property(c => c.Status)
			.HasDefaultValue(true);

		builder.Property(c => c.Address)
			.IsRequired()
			.HasMaxLength(250);

		builder.Property(c => c.Country)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(c => c.State)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(c => c.City)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(c => c.PostalCode)
			.IsRequired()
			.HasMaxLength(10);

		builder.Property(c => c.Latitude);
		builder.Property(c => c.Longitude);


		// Add relation with ClinicSession
		builder.HasMany(c => c.Sessions)
			.WithOne(s => s.Clinic)
			.HasForeignKey(s => s.ClinicId)
			.OnDelete(DeleteBehavior.Cascade);

		// Add relation with Specialization
		builder.HasOne(c => c.Specialization)
			.WithMany()
			.HasForeignKey(c => c.SpecializationId)
			.OnDelete(DeleteBehavior.SetNull);
	}
}
