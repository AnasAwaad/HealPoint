namespace HealPoint.DataAccess.Data.Configurations;
internal class CategoryConfiguration : BaseEntityConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		base.Configure(builder);

		builder.Property(e => e.Name).HasMaxLength(100);
		builder.Property(e => e.Description).HasMaxLength(500);
		builder.Property(c => c.ImagePath).HasMaxLength(255);

		builder.HasOne(e => e.ParentCategory)
			.WithMany()
			.HasForeignKey(e => e.ParentCategoryId)
			.OnDelete(DeleteBehavior.Restrict);

	}
}
