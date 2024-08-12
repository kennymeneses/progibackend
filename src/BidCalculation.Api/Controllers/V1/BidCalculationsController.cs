using BidCalculation.Application.Handlers.V1.Interfaces;
using BidCalculation.Application.Models.V1.Requests;
using BidCalculation.Application.Models.V1.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.Api.Controllers.V1;

public class BidCalculationsController(ICarCostCalculationHandler handler) : BaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(CarCostCalculationResponse), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public IActionResult GetCalculation([FromBody] CarCostCalculationRequest request)
    {
        var result = handler.Handle(request);

        return result.Match(
            calculation => Ok(calculation),
            error => Problem(error.Message));
    }
}