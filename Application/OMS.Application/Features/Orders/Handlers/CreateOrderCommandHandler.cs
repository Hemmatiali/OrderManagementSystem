using System.Net;
using AutoMapper;
using OMS.Application.Features.Base;
using OMS.Application.Features.Orders.Commands;
using OMS.Domain.Entities;
using OMS.Domain.Shared.Models;
using OMS.Infrastructure.Persistence.Data.Repositories;

namespace OMS.Application.Features.Orders.Handlers;


public class CreateOrderCommandHandler : BaseCommandHandler<CreateOrderCommand, OperationResultModel>
{
    private readonly IBaseRepository<Order> _orderRepository;
    private readonly IBaseRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(
        IRepositoryFactory repositoryFactory,
        IMapper mapper)
    {
        _orderRepository = repositoryFactory.GetRepository<Order>();
        _userRepository = repositoryFactory.GetRepository<User>();
        _mapper = mapper;
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

            return OperationResultModel.Success().WithStatusCode(HttpStatusCode.Created);
        }
        catch (Exception ex)
        {
            return OperationResultModel.Fail("Internal Server Error: " + ex.Message)
                .WithStatusCode(HttpStatusCode.InternalServerError);
        }
    }
}
