using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Services;
public class ClinicService : IClinicService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	private readonly IFileStorageService _fileStorage;

	public ClinicService(IUnitOfWork unitOfWork, IMapper mapper, IFileStorageService fileStorage)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_fileStorage = fileStorage;
	}

	public IEnumerable<ClinicListDto> GetAllClinics()
	{
		var clinics = _unitOfWork.Clinics.GetAll();
		return _mapper.Map<IEnumerable<ClinicListDto>>(clinics);
	}

	public async Task CreateClinicAsync(CreateClinicDto clinicDto)
	{
		var clinic = _mapper.Map<Clinic>(clinicDto);

		clinic.CreatedOn = DateTime.Now;

		var imagePath = await _fileStorage.UploadFileAsync(clinicDto.ImageFile, "clinics");
		clinic.ImagePath = imagePath ?? "/images/clinics/default-clinic.png";

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

	public async Task<UpdateClinicDto?> UpdateClinicAsync(UpdateClinicDto clinicDto)
	{
		var existingClinic = _unitOfWork.Clinics.FindById(clinicDto.Id);

		if (existingClinic is null)
			return null;

		_mapper.Map(clinicDto, existingClinic);

		if (clinicDto.ImageFile is not null)
		{
			_fileStorage.DeleteFile(clinicDto.ImagePath);
			var imagePath = await _fileStorage.UploadFileAsync(clinicDto.ImageFile, "clinics");

			existingClinic.ImagePath = imagePath ?? "/images/clinics/default-clinic.png";

		}



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

	public IEnumerable<ClinicListDto> GetClinicsLookup()
	{
		var clinics = _unitOfWork.Clinics.GetActiveClinics();

		return _mapper.Map<IEnumerable<ClinicListDto>>(clinics);
	}
}
