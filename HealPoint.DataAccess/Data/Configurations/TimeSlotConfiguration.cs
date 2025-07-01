namespace HealPoint.DataAccess.Data.Configurations;
internal class TimeSlotConfiguration : BaseEntityConfiguration<TimeSlot>, IEntityTypeConfiguration<TimeSlot>
{
	public void Configure(EntityTypeBuilder<TimeSlot> builder)
	{
		base.Configure(builder);

		builder.HasOne(e => e.Doctor)
				.WithMany(d => d.TimeSlots)
				.HasForeignKey(e => e.DoctorId)
				.OnDelete(DeleteBehavior.Cascade);
	}
}
