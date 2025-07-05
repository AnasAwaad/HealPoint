namespace HealPoint.DataAccess.Data.Configurations;

internal class ServiceConfiguration : BaseEntityConfiguration<Service>, IEntityTypeConfiguration<Service>
{

	public void Configure(EntityTypeBuilder<Service> builder)
	{

		base.Configure(builder);

		builder.HasKey(c => c.Id);

		builder.Property(c => c.Name)
		.HasMaxLength(100);

		builder.Property(c => c.Description)
		.HasMaxLength(500);

		builder.Property(d => d.ImageUrl)
			.HasMaxLength(255);

		// Configure the relationship with DoctorService

		builder.HasMany(c => c.Doctors)
		.WithOne(d => d.Service)
		.HasForeignKey(d => d.ServiceId)
		.OnDelete(DeleteBehavior.Restrict);

	}

}
