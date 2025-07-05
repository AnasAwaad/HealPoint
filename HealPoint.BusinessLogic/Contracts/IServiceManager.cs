namespace HealPoint.BusinessLogic.Contracts;
public interface IServiceManager
{
	Task<ServiceDto> CreateServiceAsync(ServiceFormDto model);
	IEnumerable<ServiceDto> GetAllServices();
	ServiceFormDto? GetServiceById(int id);
	Task<ServiceDto?> UpdateServiceAsync(ServiceFormDto model);
	(bool? isDeleted, string? lastUpdatedOn) UpdateServiceStatus(int id);
}
