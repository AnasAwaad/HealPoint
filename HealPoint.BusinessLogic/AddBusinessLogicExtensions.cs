using Microsoft.Extensions.DependencyInjection;

namespace Vezeeta.BusinessLogic;
public static class AddBusinessLogicExtensions
{
    public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {

        //services.AddScoped<ICategoryService, CategoryService>();
        //services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
