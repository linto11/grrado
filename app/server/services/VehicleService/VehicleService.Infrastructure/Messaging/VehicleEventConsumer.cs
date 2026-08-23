using GRRADO.Shared.Domain.Events;
using GRRADO.Shared.Infrastructure.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VehicleService.Application.Abstractions;

namespace VehicleService.Infrastructure.Messaging;

public class VehicleEventConsumer : EventConsumerHostedService
{
    protected override string ServiceName => "vehicle-service";

    public VehicleEventConsumer(
        IConfiguration configuration,
        IServiceProvider serviceProvider,
        ILogger<VehicleEventConsumer> logger)
        : base(configuration, serviceProvider, logger)
    {
    }

    protected override void ConfigureSubscriptions()
    {
        _subscriber.Subscribe<UserDeletedEvent>(async @event =>
        {
            _logger.LogInformation("Received UserDeletedEvent for UserId: {UserId}", @event.UserId);

            using var scope = _serviceProvider.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IVehicleUnitOfWork>();

            var vehicles = await unitOfWork.Vehicles.FindAsync(v => v.UserId == @event.UserId);
            foreach (var vehicle in vehicles)
            {
                await unitOfWork.Vehicles.DeleteAsync(vehicle.Id);
            }
            await unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Soft-deleted {Count} vehicles for UserId: {UserId}", vehicles.Count(), @event.UserId);
        });
    }
}
