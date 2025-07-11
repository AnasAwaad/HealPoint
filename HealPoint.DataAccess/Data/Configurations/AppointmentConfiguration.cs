namespace HealPoint.DataAccess.Data.Configurations;
internal class AppointmentConfiguration : BaseEntityConfiguration<Appointment>, IEntityTypeConfiguration<Appointment>
{
	public void Configure(EntityTypeBuilder<Appointment> builder)
	{
		base.Configure(builder);

		// Appointment Information
		builder.Property(d => d.AppointmentDate)
			.HasColumnType("date");

		builder.Property(d => d.AppointmentTime)
			.HasColumnType("time");

		builder.Property(d => d.Status)
			.HasConversion<string>()
			.HasMaxLength(20);

		// Patient information

		builder.Property(d => d.FirstName)
			.HasMaxLength(100);

		builder.Property(d => d.LastName)
			.HasMaxLength(100);

		builder.Property(d => d.Gender)
			.HasMaxLength(10);

		builder.Property(d => d.Phone)
			.HasMaxLength(20);

		builder.Property(d => d.Email)
			.HasMaxLength(150);

		builder.Property(d => d.DateOfBirth)
			.HasColumnType("date");

		// Address
		builder.Property(d => d.Address)
			.HasMaxLength(255);

		builder.Property(a => a.Address)
			.HasMaxLength(200);

		builder.Property(a => a.AppointmentReason)
			.HasMaxLength(500);

		builder.Property(a => a.MedicalDocument)
			.HasColumnType("nvarchar(max)");

		// Configure the relationship with Doctor and Patient
		builder.HasOne(d => d.Doctor)
			.WithMany(s => s.Appointments)
			.HasForeignKey(d => d.DoctorId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(d => d.Patient)
			.WithMany(d => d.Appointments)
			.HasForeignKey(d => d.PatientId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
