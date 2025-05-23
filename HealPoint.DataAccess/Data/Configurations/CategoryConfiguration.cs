namespace HealPoint.DataAccess.Data.Configurations;
internal class CategoryConfiguration : BaseEntityConfiguration<Category>, IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Name).HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(500);
        builder.Property(e => e.ImagePath).HasMaxLength(255);

        builder.Property(e => e.IsFeatured).HasDefaultValue(false);
        builder.Property(e => e.Status).HasDefaultValue(true);


        builder.HasOne(e => e.ParentCategory)
            .WithMany()
            .HasForeignKey(e => e.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Add unique constraint on name
        builder.HasIndex(s => s.Name)
               .IsUnique();
    }
}
