namespace HealPoint.DataAccess.Data.Configurations;
internal class DoctorConfiguration : BaseEntityConfiguration<Doctor>, IEntityTypeConfiguration<Doctor>
{
	public void Configure(EntityTypeBuilder<Doctor> builder)
	{
		base.Configure(builder);


		builder.Property(d => d.DateOfBirth)
			.HasColumnType("date")
			.IsRequired(false);

		builder.Property(d => d.Gender)
			.HasMaxLength(10)
			.IsRequired(false);

		builder.Property(d => d.ProfilePhotoPath)
			.HasMaxLength(255)
			.IsRequired(false);

		// Address
		builder.Property(d => d.Address)
			.HasMaxLength(255)
			.IsRequired(false);

		builder.Property(d => d.City)
			.HasMaxLength(100)
			.IsRequired(false);

		builder.Property(d => d.State)
			.HasMaxLength(100)
			.IsRequired(false);

		builder.Property(d => d.PostalCode)
			.HasMaxLength(20)
			.IsRequired(false);

		builder.Property(d => d.Country)
			.HasMaxLength(100)
			.IsRequired(false);

		builder.Property(d => d.Experience)
			.IsRequired(false);

		// Relations
		builder.Property(d => d.SpecializationId)
			.IsRequired();


		builder.Property(d => d.ApplicationUserId)
			.HasMaxLength(450)
			.IsRequired(false);

		builder.HasOne(d => d.Specialization)
			.WithMany(s => s.Doctors)
			.HasForeignKey(d => d.SpecializationId)
			.OnDelete(DeleteBehavior.Restrict);


		builder.HasOne(d => d.ApplicationUser)
			.WithOne(u => u.Doctor)
			.HasForeignKey<Doctor>(d => d.ApplicationUserId)
			.OnDelete(DeleteBehavior.SetNull);
	}
}
