 using Microsoft.AspNetCore.Mvc;
using System.Net;
using MediatR;
using OMS.Application.Features.Orders.Dtos;
using OMS.Application.Features.Orders.Queries;

namespace OMS.Api.Controllers;

public class OrdersController : BaseController
{
    // Fields
    private readonly IMediator _mediator;

    // Constructor
    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Methods
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<OrderDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
    public async Task<IActionResult> GetOrders()
    {
        try
        {
            // Get all orders
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(orders);
        }
        catch (Exception)
        {
            return Problem(detail: "Unexpected error happened.");
        }
    }
}