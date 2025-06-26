using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.DataAccess.Contracts;

namespace HealPoint.BusinessLogic.Services;
internal class DoctorService(IUnitOfWork unitOfWork, IMapper mapper) : IDoctorService
{

	#region Actions

	public IEnumerable<DoctorDto> GetAll()
	{
		var doctors = unitOfWork.Doctors.GetAllWithDetails();

		return mapper.Map<IEnumerable<DoctorDto>>(doctors);
	}


	#endregion
}
