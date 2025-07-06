namespace HealPoint.DataAccess.Entities;
public class DoctorSymptom
{
	public int DoctorId { get; set; }
	public Doctor Doctor { get; set; }

	public int SymptomId { get; set; }
	public Symptom Symptom { get; set; }
}
