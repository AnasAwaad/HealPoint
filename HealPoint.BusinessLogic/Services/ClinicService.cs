using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.DTOs;
using HealPoint.DataAccess.Contracts;

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
}
