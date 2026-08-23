using GRRADO.Shared.Domain.Events;
using GRRADO.Shared.Infrastructure.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceHistoryService.Application.Abstractions;

namespace ServiceHistoryService.Infrastructure.Messaging;

public class ServiceHistoryEventConsumer : EventConsumerHostedService
{
    protected override string ServiceName => "servicehistory-service";

    public ServiceHistoryEventConsumer(
        IConfiguration configuration,
        IServiceProvider serviceProvider,
        ILogger<ServiceHistoryEventConsumer> logger)
        : base(configuration, serviceProvider, logger)
    {
    }

    protected override void ConfigureSubscriptions()
    {
        _subscriber.Subscribe<VehicleDeletedEvent>(async @event =>
        {
            _logger.LogInformation("Received VehicleDeletedEvent for VehicleId: {VehicleId}", @event.VehicleId);

            using var scope = _serviceProvider.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IServiceHistoryUnitOfWork>();

            var records = await unitOfWork.ServiceHistories.FindAsync(sh => sh.VehicleId == @event.VehicleId);
            foreach (var record in records)
            {
                await unitOfWork.ServiceHistories.DeleteAsync(record.Id);
            }
            await unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Soft-deleted {Count} service history records for VehicleId: {VehicleId}", records.Count(), @event.VehicleId);
        });

        _subscriber.Subscribe<GarageDeletedEvent>(async @event =>
        {
            _logger.LogInformation("Received GarageDeletedEvent for GarageId: {GarageId}", @event.GarageId);

            using var scope = _serviceProvider.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IServiceHistoryUnitOfWork>();

            var records = await unitOfWork.ServiceHistories.FindAsync(sh => sh.GarageId == @event.GarageId);
            foreach (var record in records)
            {
                await unitOfWork.ServiceHistories.DeleteAsync(record.Id);
            }
            await unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Soft-deleted {Count} service history records for GarageId: {GarageId}", records.Count(), @event.GarageId);
        });

        _subscriber.Subscribe<ServiceDeletedEvent>(async @event =>
        {
            _logger.LogInformation("Received ServiceDeletedEvent for ServiceId: {ServiceId}", @event.ServiceId);

            using var scope = _serviceProvider.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IServiceHistoryUnitOfWork>();

            var records = await unitOfWork.ServiceHistories.FindAsync(sh => sh.ServiceId == @event.ServiceId);
            foreach (var record in records)
            {
                await unitOfWork.ServiceHistories.DeleteAsync(record.Id);
            }
            await unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Soft-deleted {Count} service history records for ServiceId: {ServiceId}", records.Count(), @event.ServiceId);
        });
    }
}
