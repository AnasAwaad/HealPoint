namespace HealPoint.BusinessLogic.Contracts;
public interface IServiceManager
{
	ServiceDto CreateService(ServiceFormDto model);
	IEnumerable<ServiceDto> GetAllServices();
}
