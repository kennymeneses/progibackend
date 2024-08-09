using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.Api.Controllers.V1;

public class BidCalculationsController : BaseController
{
    [HttpGet]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetCalculation(CancellationToken cancellationToken)
    {
        
        return Ok("V1");
    }
}