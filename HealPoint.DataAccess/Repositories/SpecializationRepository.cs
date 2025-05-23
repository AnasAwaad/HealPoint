using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Data;

namespace HealPoint.DataAccess.Repositories;
internal class SpecializationRepository : Repository<Specialization>, ISpecializationRepository
{
	public SpecializationRepository(ApplicationDbContext context) : base(context)
	{
	}


	public override IEnumerable<Specialization> GetAll()
	{
		return _context.Specializations
			.Where(s => !s.IsDeleted)
			.Include(s => s.Category)
			.AsEnumerable();
	}
	public async Task<Specialization?> GetByIdAsync(int id)
	{
		return await _context.Specializations
			.Include(s => s.Category)
			.FirstOrDefaultAsync(s => s.Id == id);
	}

	public bool IsSpecializationNameAllowed(string specializationName, int? excludeSpecializationId = null)
	{
		var spec = _context.Specializations.SingleOrDefault(s => s.Name == specializationName && !s.IsDeleted);

		return spec is null || spec.Id == excludeSpecializationId;
	}
}
