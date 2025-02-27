using System.ComponentModel.DataAnnotations;

namespace OMS.Application.Features.Orders.ViewModels;

public class CreateOrderViewModel
{
    [Required(ErrorMessage = "UserId is required.")]
    [Range(1, 10000, ErrorMessage = "Invalid range of UserId.")]
    public int UserId { get; set; }
    public string? Description { get; set; }
}