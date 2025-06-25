namespace HealPoint.DataAccess.Contracts;
public interface IClinicRepository : IRepository<Clinic>
{
	Clinic? GetClinicWithSpecializations(int id);
}
