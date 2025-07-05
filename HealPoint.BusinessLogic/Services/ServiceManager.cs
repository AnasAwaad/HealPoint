using AutoMapper;
using HealPoint.BusinessLogic.Contracts;
using HealPoint.DataAccess.Contracts;
using HealPoint.DataAccess.Entities;

namespace HealPoint.BusinessLogic.Services;
internal class ServiceManager(IUnitOfWork unitOfWork, IMapper mapper) : IServiceManager
{
	public ServiceDto CreateService(ServiceFormDto model)
	{
		var service = mapper.Map<Service>(model);

		unitOfWork.Services.Insert(service);
		unitOfWork.SaveChanges();

		return mapper.Map<ServiceDto>(service);
	}

	public IEnumerable<ServiceDto> GetAllServices()
	{
		var services = unitOfWork.Services.GetAll();
		return mapper.Map<IEnumerable<ServiceDto>>(services);
	}

	public ServiceFormDto? GetServiceById(int id)
	{
		var service = unitOfWork.Services.FindById(id);

		return mapper.Map<ServiceFormDto>(service);
	}

	public ServiceDto? UpdateService(ServiceFormDto model)
	{
		var existingService = unitOfWork.Services.FindById(model.Id);

		if (existingService == null)
			return null;

		mapper.Map(model, existingService);
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
