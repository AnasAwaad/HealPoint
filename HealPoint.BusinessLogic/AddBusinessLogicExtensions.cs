using HealPoint.BusinessLogic.Contracts;
using HealPoint.BusinessLogic.Mapping;
using HealPoint.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HealPoint.BusinessLogic;
public static class AddBusinessLogicExtensions
{
	public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
	{

		services.AddScoped<ICategoryService, CategoryService>();
		services.AddAutoMapper(typeof(DomainProfile));
		//services.AddScoped<IProductService, ProductService>();

		return services;
	}
}
