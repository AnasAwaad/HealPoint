using HealPoint.DataAccess.Enums;

namespace HealPoint.DataAccess.Entities;
public class DoctorSchedule : BaseEntity
{
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public RecurrencePattern Recurrence { get; set; }
	public int DoctorId { get; set; }
	public Doctor? Doctor { get; set; }
	public int ClinicId { get; set; }
	public Clinic? Clinic { get; set; }
	public ICollection<DoctorScheduleDetails> DoctorScheduleDetails { get; set; } = new List<DoctorScheduleDetails>();

}
