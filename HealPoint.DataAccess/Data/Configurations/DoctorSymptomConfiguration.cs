namespace HealPoint.DataAccess.Data.Configurations;
internal class DoctorSymptomConfiguration : IEntityTypeConfiguration<DoctorSymptom>
{
	public void Configure(EntityTypeBuilder<DoctorSymptom> builder)
	{
		builder.HasKey(ds => new { ds.DoctorId, ds.SymptomId });

		builder.HasOne(d => d.Doctor)
			.WithMany(d => d.Symptoms)
			.HasForeignKey(d => d.DoctorId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(s => s.Symptom)
			.WithMany(s => s.Doctors)
			.HasForeignKey(s => s.SymptomId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
