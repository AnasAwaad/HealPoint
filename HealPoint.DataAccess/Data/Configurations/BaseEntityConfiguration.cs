namespace HealPoint.DataAccess.Data.Configurations;
internal class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(e => e.CreatedOn).HasDefaultValueSql("GETDATE()");

        builder.Property(e => e.LastUpdatedOn).HasComputedColumnSql("GETDATE()");

        builder.Property(e => e.IsDeleted)
               .HasDefaultValue(false);
    }
}
