namespace HealPoint.DataAccess.Entities;
public class Symptom : BaseEntity
{
	public string Name { get; set; } = null!;
	public ICollection<DoctorSymptom> Doctors { get; set; } = new List<DoctorSymptom>();
}
