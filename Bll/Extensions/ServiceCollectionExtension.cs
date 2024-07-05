using Bll.Mappers;
using Bll.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bll.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddBllServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<OwnerService>()
            .AddScoped<OwnerDtoMapper>();

        return serviceCollection;
    }
}