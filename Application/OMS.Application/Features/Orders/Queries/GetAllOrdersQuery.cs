using OMS.Application.Features.Base;
using OMS.Application.Features.Orders.Dtos;

namespace OMS.Application.Features.Orders.Queries;

public class GetAllOrdersQuery : BaseQuery<IEnumerable<OrderDto>>
{ }
