namespace HealPoint.BusinessLogic.Contracts;
public interface IServiceManager
{
	ServiceDto CreateService(ServiceFormDto model);
	IEnumerable<ServiceDto> GetAllServices();
	ServiceFormDto? GetServiceById(int id);
	ServiceDto? UpdateService(ServiceFormDto model);
	(bool? isDeleted, string? lastUpdatedOn) UpdateServiceStatus(int id);
}
