using MediatR;
using OMS.Application.Features.Orders.Events;
using System.Reflection;

namespace OMS.Application.Features.Orders.EventHandlers;

public class LogOrderHandler : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        // Simulate like production env
        await Task.Delay(2000, cancellationToken);

        // Get current directory of this file
        string directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? Directory.GetCurrentDirectory();
        string logPath = Path.Combine(directoryPath, "LogOrderHandlerLogs", "order_logs.txt");

        // Ensure directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(logPath)!);

        // Log message
        string logMessage = $"[{notification.CreatedAt}] Order Created: {notification.UserFullName} - {notification.Description}\n";

        await File.AppendAllTextAsync(logPath, logMessage, cancellationToken);
    }
}