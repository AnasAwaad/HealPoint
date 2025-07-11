﻿namespace HealPoint.DataAccess.Data.Configurations;
internal class DepartmentConfiguration : BaseEntityConfiguration<Department>, IEntityTypeConfiguration<Department>
{
	public void Configure(EntityTypeBuilder<Department> builder)
	{
		base.Configure(builder);

		builder.Property(e => e.Name).HasMaxLength(100);
		builder.Property(e => e.Description).HasMaxLength(500);
		builder.Property(e => e.ImagePath).HasMaxLength(255);

		builder.Property(e => e.IsFeatured).HasDefaultValue(false);

		// Add unique constraint on name
		builder.HasIndex(s => s.Name)
			   .IsUnique();

		builder.HasMany(d => d.Doctors)
			.WithOne(d => d.Department)
			.HasForeignKey(d => d.DepartmentId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
