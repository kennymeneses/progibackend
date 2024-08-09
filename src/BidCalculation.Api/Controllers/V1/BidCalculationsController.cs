using BidCalculation.Application.Models.V1.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.Api.Controllers.V1;

public class BidCalculationsController : BaseController
{
    [HttpGet]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetCalculation([FromQuery] CarCostCalculationRequest request, CancellationToken cancellationToken)
    {
        return Ok("V1");
    }
}