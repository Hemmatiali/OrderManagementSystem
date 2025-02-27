using OMS.Application.Features.Base;
using OMS.Application.Features.Orders.ViewModels;
using OMS.Domain.Shared.Models;

namespace OMS.Application.Features.Orders.Commands;

public class CreateOrderCommand : BaseCommand<OperationResultModel>
{
    public CreateOrderViewModel CreateOrderViewModel { get; set; } = new();
}