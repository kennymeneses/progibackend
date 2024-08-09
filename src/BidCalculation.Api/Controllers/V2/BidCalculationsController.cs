using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.Api.Controllers.V2;

[ApiVersion("2.0")]
public class BidCalculationsController : BaseController
{
    [HttpGet]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetCalculation(CancellationToken cancellationToken)
    {
        return Ok("V2");
    }
}