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
}
