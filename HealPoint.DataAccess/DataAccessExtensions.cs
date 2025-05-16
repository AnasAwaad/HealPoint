using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vezeeta.DataAccess.Contracts;
using Vezeeta.DataAccess.Data;

namespace Vezeeta.DataAccess;
public static class DataAccessExtensions
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("salesConnection"));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
