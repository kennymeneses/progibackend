using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class BaseController: ControllerBase
{
    private ObjectResult Problem(Exception exception)
    {
        return Problem(title: exception.Message);
    }
}