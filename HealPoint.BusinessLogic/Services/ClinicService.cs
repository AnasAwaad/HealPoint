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

    public UpdateClinicDto? GetClinicById(int id)
    {
        var clinic = _unitOfWork.Clinics.GetClinicWithSpecializations(id);

        if (clinic is null)
            return null;

        return _mapper.Map<UpdateClinicDto>(clinic);
    }

    public UpdateClinicDto? UpdateClinic(UpdateClinicDto clinicDto)
    {
        var existingClinic = _unitOfWork.Clinics.FindById(clinicDto.Id);

        if (existingClinic is null)
            return null;

        _mapper.Map(clinicDto, existingClinic);

        _unitOfWork.Clinics.Update(existingClinic);
        _unitOfWork.SaveChanges();

        return clinicDto;
    }


    public bool DeleteClinic(int id)
    {
        var clinic = _unitOfWork.Clinics.FindById(id);

        if (clinic is null)
            return false;

        _unitOfWork.Clinics.Delete(id);
        _unitOfWork.SaveChanges();

        return true;
    }

}
