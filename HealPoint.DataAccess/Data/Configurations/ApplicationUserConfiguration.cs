namespace HealPoint.DataAccess.Data.Configurations;
internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
	public void Configure(EntityTypeBuilder<ApplicationUser> builder)
	{
		builder.Property(u => u.FirstName)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(u => u.LastName)
			.HasMaxLength(100)
			.IsRequired(false);

		builder.Property(e => e.CreatedOn).HasDefaultValueSql("GETDATE()");

		builder.Property(e => e.IsDeleted)
			   .HasDefaultValue(false);

		builder.Property(u => u.CreatedById)
			.HasMaxLength(450)
			.IsRequired(false);

		builder.Property(u => u.LastUpdatedOn)
			.IsRequired(false);

		builder.Property(u => u.LastUpdatedById)
			.HasMaxLength(450)
			.IsRequired(false);


		builder.HasOne(u => u.Doctor)
			.WithOne(d => d.ApplicationUser)
			.HasForeignKey<Doctor>(d => d.ApplicationUserId)
			.OnDelete(DeleteBehavior.SetNull);

	}
}
