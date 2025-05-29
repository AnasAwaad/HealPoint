using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Services;
public class ClinicService : IClinicService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public ClinicService(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public IEnumerable<ClinicListDto> GetAllClinics()
	{
		var clinics = _unitOfWork.Clinics.GetAll();
		return _mapper.Map<IEnumerable<ClinicListDto>>(clinics);
	}

	public void CreateClinic(CreateClinicDto clinicDto)
	{
		var clinic = _mapper.Map<Clinic>(clinicDto);

		clinic.CreatedOn = DateTime.Now;

		_unitOfWork.Clinics.Insert(clinic);
		_unitOfWork.SaveChanges();
	}
}
