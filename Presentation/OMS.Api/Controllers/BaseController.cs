using Microsoft.AspNetCore.Mvc;

namespace OMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
}