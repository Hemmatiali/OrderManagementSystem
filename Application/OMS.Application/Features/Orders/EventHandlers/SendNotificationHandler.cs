using MediatR;
using OMS.Application.Features.Orders.Events;

namespace OMS.Application.Features.Orders.EventHandlers;

public class SendNotificationHandler : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Simulate like production env
        await Task.Delay(500, cancellationToken);

        Console.WriteLine($"Notification: New order created for {notification.UserFullName}. Description: {notification.Description}");
    }
}