using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dal.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<CatApiDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnectionString")));

        return serviceCollection;
    }
}