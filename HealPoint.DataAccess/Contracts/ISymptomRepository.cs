namespace HealPoint.DataAccess.Contracts;
public interface ISymptomRepository : IRepository<Symptom>
{
	bool IsSymptomNameAllowed(string symptomName, int? excludeSymptomId = null);
	IEnumerable<Symptom> GetActiveSymptoms();
}
