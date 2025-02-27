namespace OMS.Application.Features.Orders.Dtos;

public class OrderDto
{
    public string UserName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
