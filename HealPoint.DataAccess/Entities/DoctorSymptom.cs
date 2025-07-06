namespace HealPoint.DataAccess.Entities;
public class DoctorSymptom
{
	public int DoctorId { get; set; }
	public Doctor Doctor { get; set; }

	public int SymptomId { get; set; }
	public Symptom Symptom { get; set; }

	public string? CreatedById { get; set; }
	public ApplicationUser? CreatedBy { get; set; }
	public DateTime CreatedOn { get; set; }
	public string? LastUpdatedById { get; set; }
	public ApplicationUser? LastUpdatedBy { get; set; }
	public DateTime? LastUpdatedOn { get; set; }
	public bool IsDeleted { get; set; }
}
