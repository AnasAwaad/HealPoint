using HealPoint.DataAccess.Enums;

namespace HealPoint.DataAccess.Data.Configurations;
internal class DoctorConfiguration : BaseEntityConfiguration<Doctor>, IEntityTypeConfiguration<Doctor>
{
	public void Configure(EntityTypeBuilder<Doctor> builder)
	{
		base.Configure(builder);

		// Personal Information
		builder.Property(d => d.DateOfBirth)
			.HasColumnType("date");

		builder.Property(d => d.Gender)
			.HasMaxLength(10);

		builder.Property(d => d.ProfilePhotoPath)
			.HasMaxLength(255);

		// Address
		builder.Property(d => d.Address)
			.HasMaxLength(255);

		builder.Property(d => d.City)
			.HasMaxLength(100);

		builder.Property(d => d.State)
			.HasMaxLength(100);

		builder.Property(d => d.PostalCode)
			.HasMaxLength(20);

		builder.Property(d => d.Country)
			.HasMaxLength(100);

		//Contact Information
		builder.Property(d => d.EmergencyContactName)
			.HasMaxLength(100);

		builder.Property(d => d.EmergencyContactPhone)
			.HasMaxLength(15);

		//Professional Details

		builder.Property(d => d.MedicalLicenseNumber)
			.HasMaxLength(50);

		builder.Property(d => d.LicenseExpiryDate)
			.HasColumnType("date");

		builder.Property(d => d.Qualifications)
			.HasMaxLength(500);

		builder.Property(d => d.YearOfExperience)
			.HasMaxLength(30);

		builder.Property(d => d.OperationMode)
			.HasDefaultValue(DoctorOperationMode.Telehealth);

		// --- Education & Training

		builder.Property(d => d.Education)
			  .HasMaxLength(500);

		builder.Property(d => d.Certifications)
			  .HasMaxLength(500);

		//Department & Position
		builder.Property(d => d.Position)
			.HasMaxLength(100);

		// Relations
		builder.Property(d => d.SpecializationId)
			.IsRequired();


		builder.Property(d => d.ApplicationUserId)
			.HasMaxLength(450)
			.IsRequired(false);

		// Configure the relationship with Specialization, Department, ApplicationUser and DoctorService
		builder.HasOne(d => d.Specialization)
			.WithMany(s => s.Doctors)
			.HasForeignKey(d => d.SpecializationId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(d => d.Department)
			.WithMany(d => d.Doctors)
			.HasForeignKey(d => d.DepartmentId)
			.OnDelete(DeleteBehavior.Restrict);


		builder.HasOne(d => d.ApplicationUser)
			.WithOne(u => u.Doctor)
			.HasForeignKey<Doctor>(d => d.ApplicationUserId)
			.OnDelete(DeleteBehavior.SetNull);

		builder.HasMany(d => d.DoctorServices)
			.WithOne(ds => ds.Doctor)
			.HasForeignKey(ds => ds.DoctorId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
