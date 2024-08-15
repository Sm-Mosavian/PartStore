using PartsStoreAPI.Core.Interfaces;
using PartStore.Application.Interfaces.Repositories;
using PartStore.Infrastructure.Implementations.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PartStore.Infrastructure.Implementations.Services;

namespace PartStore.Infrastructure;

public static class InfraStructureRegistrartion
{
    public static IServiceCollection ConfigureInfraStructureServices(this IServiceCollection services, IConfiguration configuration)
    {
       

        services.AddScoped(typeof(IGeneralRepository<>), typeof(GeneralRepository<>));
        services.AddScoped<IPartRepository, PartRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IPartService, PartService>();

        return services;
    }
}