using Microsoft.AspNetCore.Mvc;
using System.Net;
using MediatR;
using OMS.Application.Features.Orders.Commands;
using OMS.Application.Features.Orders.Dtos;
using OMS.Application.Features.Orders.Queries;
using OMS.Application.Features.Orders.ViewModels;

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

    [HttpPost]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderViewModel viewModel)
    {
        try
        {
            // Check model validation
            if (!ModelState.IsValid)
                return BadRequest("Invalid input parameters.");

            // Create command
            var createOrderCommand = new CreateOrderCommand() { CreateOrderViewModel = viewModel };

            // Create order
            var result = await _mediator.Send(createOrderCommand);

            // Result
            return result.WasSuccess
                ? StatusCode((int)result.StatusCode, true)
                : StatusCode((int)result.StatusCode, result.ErrorMessage);
        }
        catch (Exception ex)
        {
            return Problem(detail: ex.Message);
        }
    }
}