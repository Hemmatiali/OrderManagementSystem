using MediatR;
using Microsoft.AspNetCore.Mvc;
using OMS.Application.Features.Users.Dtos;
using OMS.Application.Features.Users.Queries;
using System.Net;

namespace OMS.Api.Controllers;

public class UserController : BaseController
{
    // Fields
    private readonly IMediator _mediator;

    // Constructor
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Methods
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
    public async Task<IActionResult> GetUsers()
    {
        try
        {
            // Get all users
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }
        catch (Exception e)
        {
            return Problem(detail: "UnExpected error happened.");
        }
    }
}