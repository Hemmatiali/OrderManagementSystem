using MediatR;
using OMS.Application.Features.Orders.Events;

namespace OMS.Application.Features.Orders.EventHandlers;

public class UpdateInventoryHandler : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Simulate like production env
        await Task.Delay(1000, cancellationToken);

        Console.WriteLine($"Inventory Updated: Order {notification.Description} for {notification.UserFullName} processed.");
    }
}