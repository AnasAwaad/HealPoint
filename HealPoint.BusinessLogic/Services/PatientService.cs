using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.DataAccess.Contracts;

namespace HealPoint.BusinessLogic.Services;
internal class PatientService(IUnitOfWork unitOfWork, IMapper mapper) : IPatientService
{
	public IEnumerable<PatientDto> GetAllPatientsWithDetails()
	{
		var patients = unitOfWork.Patients.GetAllWithDetails();

		return mapper.ProjectTo<PatientDto>(patients).ToList();
	}
}
