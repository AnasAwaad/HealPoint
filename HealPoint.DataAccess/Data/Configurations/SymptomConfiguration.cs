namespace HealPoint.DataAccess.Data.Configurations;
internal class SymptomConfiguration : BaseEntityConfiguration<Symptom>, IEntityTypeConfiguration<Symptom>
{
	public void Configure(EntityTypeBuilder<Symptom> builder)
	{
		base.Configure(builder);

		builder.Property(e => e.Name).HasMaxLength(100);

		builder.HasIndex(e => e.Name)
			.IsUnique();

		builder.HasMany(d => d.Doctors)
			.WithOne(d => d.Symptom)
			.HasForeignKey(d => d.SymptomId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
