using CatApi.Mappers;

namespace CatApi.Extensions;

public static class ServiceCollectionsExtension
{
    public static IServiceCollection AddApiServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<OwnerModelMapper>();

        return serviceCollection;
    }
}