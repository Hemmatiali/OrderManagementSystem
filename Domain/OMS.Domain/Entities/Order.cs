namespace OMS.Domain.Entities;

public class Order
{
    // Properties
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? Description { get; set; }

    // Navigational properties 
    public User User { get; set; }
}