
using Microsoft.Extensions.DependencyInjection;
using ObserverPattern.Abstractions.Application.Services;
using ObserverPattern.Application.Commands;
using ObserverPattern.Application.Extensions;
using ObserverPattern.Application.Responses;
using ObserverPattern.Domain.Enums;
using ObserverPattern.Infrastructure.Extensions;

namespace ObserverPattern.Console;

internal class Program
{
    private static readonly IServiceCollection services = new ServiceCollection();
    private static IApplicationService<UpdateProductStorageCommand, UpdateStorageProductResponse> applicationService;
    private static void ConfigureServices()
    {
        services.AddApplicationServices();
        services.AddInfrastructureServices();
        var serviceProvider = services.BuildServiceProvider();
        applicationService = serviceProvider.GetRequiredService<IApplicationService<UpdateProductStorageCommand, UpdateStorageProductResponse>>();
    }
    private static void Main(string[] args)
    {
        ConfigureServices();
        applicationService.ExecuteAsync(new UpdateProductStorageCommand
        {
            ProductId = 1,
            MovementAmount = 10,
            MovementType = StorageMovementType.In,
            MovementDescription = "Adding stock to product"
        }).GetAwaiter().GetResult();

        applicationService.ExecuteAsync(new UpdateProductStorageCommand
        {
            ProductId = 1,
            MovementAmount = 10,
            MovementType = StorageMovementType.Out,
            MovementDescription = "Removing stock from product"
        }).GetAwaiter().GetResult();

        
    }
}