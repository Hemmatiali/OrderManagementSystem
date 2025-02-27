using System.Net;
using MediatR;
using OMS.Application.Features.Base;
using OMS.Application.Features.Orders.Commands;
using OMS.Application.Features.Orders.Events;
using OMS.Domain.Entities;
using OMS.Domain.Shared.Models;
using OMS.Infrastructure.Persistence.Data.Repositories;

namespace OMS.Application.Features.Orders.Handlers;


public class CreateOrderCommandHandler : BaseCommandHandler<CreateOrderCommand, OperationResultModel>
{
    private readonly IBaseRepository<Order> _orderRepository;
    private readonly IBaseRepository<User> _userRepository;
    private readonly IMediator _mediator;

    public CreateOrderCommandHandler(
        IRepositoryFactory repositoryFactory,
        IMediator mediator)
    {
        _orderRepository = repositoryFactory.GetRepository<Order>();
        _userRepository = repositoryFactory.GetRepository<User>();
        _mediator = mediator;
    }


    protected override async Task<OperationResultModel> HandleCommand(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        try
        {
            // Get model 
            var model = command.CreateOrderViewModel;

            // Fetch user from DB
            var user = await _userRepository.GetByIdAsync(model.UserId, cancellationToken);
            if (user == null)
                return OperationResultModel.Fail("UserId not found.").WithStatusCode(HttpStatusCode.NotFound);

            // Create a new order
            var order = new Order
            {
                UserId = model.UserId,
                Description = model.Description,
                CreatedAt = DateTimeOffset.UtcNow
            };

            // Add order to DB
            await _orderRepository.AddAsync(order);

            // Save changes
            await _orderRepository.SaveChangesAsync();

            // Publish OrderCreatedEvent
            await _mediator.Publish(new OrderCreatedEvent(
                userId: user.Id,
                userFullName: user.FullName,
                description: string.IsNullOrWhiteSpace(order.Description) ? string.Empty : order.Description,
                createdAt: order.CreatedAt), cancellationToken);

            return OperationResultModel.Success().WithStatusCode(HttpStatusCode.Created);
        }
        catch (Exception ex)
        {
            return OperationResultModel.Fail("Internal Server Error: " + ex.Message)
                .WithStatusCode(HttpStatusCode.InternalServerError);
        }
    }
}
