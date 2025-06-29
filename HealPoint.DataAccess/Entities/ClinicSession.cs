using HealPoint.DataAccess.Common;

namespace HealPoint.DataAccess.Entities;
public class ClinicSession : BaseEntity
{
	public DateTime StartTime { get; set; }
	public DateTime EndTime { get; set; }
	public DayOfWeek DayOfWeek { get; set; }
	public int ClinicId { get; set; }
	public Clinic Clinic { get; set; } = null!;
}
