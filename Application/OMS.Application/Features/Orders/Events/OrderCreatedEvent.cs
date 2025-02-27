using MediatR;

namespace OMS.Application.Features.Orders.Events;

public class OrderCreatedEvent : INotification
{
    public int UserId { get; }
    public string UserFullName { get; }
    public string Description { get; }
    public DateTimeOffset CreatedAt { get; }

    public OrderCreatedEvent(int userId, string userFullName, string description, DateTimeOffset createdAt)
    {
        UserId = userId;
        UserFullName = userFullName;
        Description = description;
        CreatedAt = createdAt;
    }
}