namespace OMS.Domain.Entities;

public class User
{
    // Properties
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }

    // Navigational properties 
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}