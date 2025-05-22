namespace HealPoint.DataAccess.Data.Configurations;
internal class SpecializationConfiguration : BaseEntityConfiguration<Specialization>, IEntityTypeConfiguration<Specialization>
{
	public void Configure(EntityTypeBuilder<Specialization> builder)
	{
		base.Configure(builder);

		builder.Property(e => e.Name).HasMaxLength(100);
		builder.Property(e => e.Description).HasMaxLength(500);
		builder.Property(e => e.Status).HasDefaultValue(true);

		builder.HasOne(e => e.Category)
			.WithMany()
			.HasForeignKey(e => e.CategoryId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasIndex(s => s.Name)
			   .IsUnique();
	}
}
