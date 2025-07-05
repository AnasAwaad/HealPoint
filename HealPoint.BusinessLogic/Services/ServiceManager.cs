using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Services;
internal class ServiceManager(IUnitOfWork unitOfWork, IMapper mapper, IFileStorageService fileStorage) : IServiceManager
{
	public async Task<ServiceDto> CreateServiceAsync(ServiceFormDto model)
	{
		var service = mapper.Map<Service>(model);

		service.CreatedOn = DateTime.Now;

		var imagePath = await fileStorage.UploadFileAsync(model.ImageFile, $"services");
		service.ImageUrl = imagePath ?? "/images/services/default-service.png";

		unitOfWork.Services.Insert(service);
		unitOfWork.SaveChanges();

		return mapper.Map<ServiceDto>(service);
	}

	public IEnumerable<ServiceDto> GetAllServices()
	{
		var services = unitOfWork.Services.GetAll();
		return mapper.Map<IEnumerable<ServiceDto>>(services);
	}

	public IEnumerable<DoctorServiceItemDto> GetActiveServicesForDoctor()
	{
		var services = unitOfWork.Services.GetActiveServices();

		return mapper.Map<IEnumerable<DoctorServiceItemDto>>(services);
	}

	public ServiceFormDto? GetServiceById(int id)
	{
		var service = unitOfWork.Services.FindById(id);

		return mapper.Map<ServiceFormDto>(service);
	}

	public async Task<ServiceDto?> UpdateServiceAsync(ServiceFormDto model)
	{
		var existingService = unitOfWork.Services.FindById(model.Id);

		if (existingService == null)
			return null;

		mapper.Map(model, existingService);

		if (model.ImageFile is not null)
		{
			fileStorage.DeleteFile(model.ImageUrl);
			var imagePath = await fileStorage.UploadFileAsync(model.ImageFile, "services");

			existingService.ImageUrl = imagePath ?? "/images/services/default-service.png";
		}
		else
			existingService.ImageUrl = model.ImageUrl;

		existingService.LastUpdatedOn = DateTime.Now;

		unitOfWork.SaveChanges();

		return mapper.Map<ServiceDto>(existingService);
	}

	public (bool? isDeleted, string? lastUpdatedOn) UpdateServiceStatus(int id)
	{
		var existingService = unitOfWork.Services.FindById(id);

		if (existingService == null)
			return (null, null);

		existingService.IsDeleted = !existingService.IsDeleted;
		existingService.LastUpdatedOn = DateTime.Now;

		unitOfWork.SaveChanges();

		return (existingService.IsDeleted, DateTime.Now.ToString("dddd, dd MMMM yyyy"));
	}
}
