namespace HealPoint.DataAccess.Data.Configurations;
internal class PatientConfiguration : BaseEntityConfiguration<Patient>, IEntityTypeConfiguration<Patient>
{
	public void Configure(EntityTypeBuilder<Patient> builder)
	{
		base.Configure(builder);

		builder.Property(p => p.Gender).HasMaxLength(10);
		builder.Property(p => p.Address).HasMaxLength(250);

		builder.HasOne(p => p.User)
			.WithOne()
			.HasForeignKey<Patient>(p => p.ApplicationUserId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
