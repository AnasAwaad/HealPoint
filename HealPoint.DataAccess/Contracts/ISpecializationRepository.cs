namespace HealPoint.DataAccess.Contracts;
public interface ISpecializationRepository : IRepository<Specialization>
{
	bool IsSpecializationNameAllowed(string specializationName, int? excludeSpecializationId = null);
	IEnumerable<Specialization> GetAllSpecializationWithCategories();
}
