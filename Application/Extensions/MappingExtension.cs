using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions;

internal static class MappingExtension
{
    // Adds mapster services

    public static IServiceCollection AddMapster(this IServiceCollection services)
    {

        var mappingConfig = TypeAdapterConfig.GlobalSettings;

        mappingConfig.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMapper>(new Mapper(mappingConfig));

        return services;
    }
}
