using CatApi.Filters;
using CatApi.Mappers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CatApi.Extensions;

public static class ServiceCollectionsExtension
{
    public static IServiceCollection AddApiServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<OwnerModelMapper>()
            .AddScoped<CatModelMapper>()
            .AddScoped<CustomExceptionFilter>();

        return serviceCollection;
    }
}