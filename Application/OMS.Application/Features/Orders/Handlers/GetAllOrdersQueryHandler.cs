using System.Linq.Expressions;
using AutoMapper;
using OMS.Application.Features.Base;
using OMS.Application.Features.Orders.Dtos;
using OMS.Application.Features.Orders.Queries;
using OMS.Domain.Entities;
using OMS.Infrastructure.Persistence.Data.Repositories;

namespace OMS.Application.Features.Orders.Handlers;


public class GetAllOrdersQueryHandler : BaseQueryHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>
{
    // Fields
    private readonly IBaseRepository<Order> _orderBaseRepository;
    private readonly IMapper _mapper;

    // Constructor
    public GetAllOrdersQueryHandler(
        IRepositoryFactory repositoryFactory,
        IMapper mapper)
    {
        _orderBaseRepository = repositoryFactory.GetRepository<Order>();
        _mapper = mapper;
    }

    // Methods
    protected override async Task<IEnumerable<OrderDto>> HandleQuery(GetAllOrdersQuery query, CancellationToken cancellationToken)
    {
        try
        {
            // Get all orders with user information
            var orders = await _orderBaseRepository.GetAllAsync(
                predicate: null,
                selectColumns: order => new OrderDto()
                {
                    UserName = order.User.FullName,
                    Description = order.Description,
                    CreatedAt = order.CreatedAt
                },
                includeProperties: new Expression<Func<Domain.Entities.Order, object>>[]
                {
                    item => item.User,
                },
                orderBy: items =>
                    items.OrderByDescending(p => p.CreatedAt),
                cancellationToken: cancellationToken);

            // Map orders to DTO
            return orders;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
