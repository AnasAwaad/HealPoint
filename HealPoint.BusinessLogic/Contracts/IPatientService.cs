namespace HealPoint.BusinessLogic.Contracts;
public interface IPatientService
{
	IEnumerable<PatientDto> GetAllPatientsWithDetails();
}
