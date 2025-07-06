using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Data;

namespace HealPoint.DataAccess.Repositories;
internal class SymptomRepository : Repository<Symptom>, ISymptomRepository
{
	public SymptomRepository(ApplicationDbContext context) : base(context)
	{
	}

	// Perform soft delete: Set IsDeleted to true instead of removing
	public override void Delete(int id)
	{
		var symptom = _context.Symptoms.Find(id);
		if (symptom != null)
		{

			symptom.IsDeleted = true;
			symptom.LastUpdatedOn = DateTime.Now;
		}
	}

	public bool IsSymptomNameAllowed(string symptomName, int? excludeSymptomId = null)
	{
		var symptom = _context.Symptoms.SingleOrDefault(c => c.Name == symptomName && !c.IsDeleted);

		return symptom is null || symptom.Id.Equals(excludeSymptomId);
	}

	public IEnumerable<Symptom> GetActiveSymptoms()
	{
		return _context.Symptoms
			.Where(d => !d.IsDeleted)
			.AsEnumerable();
	}
}
