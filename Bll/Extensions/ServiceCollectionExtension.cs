using Bll.Mappers;
using Bll.Services.Cat;
using Bll.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace Bll.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddBllServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IOwnerService, OwnerService>()
            .AddScoped<ICatService, CatService>()
            .AddScoped<OwnerDtoMapper>()
            .AddScoped<CatDtoMapper>();

        return serviceCollection;
    }
}