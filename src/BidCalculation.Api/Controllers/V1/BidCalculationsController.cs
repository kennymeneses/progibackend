using BidCalculation.Application.Configuration;
using BidCalculation.Application.Handlers.V1.Interfaces;
using BidCalculation.Application.Models.V1.Requests;
using BidCalculation.Application.Models.V1.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.Api.Controllers.V1;

public class BidCalculationsController(ICarCostCalculationHandler handler) : BaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(CarCostCalculationResponse), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public IActionResult GetCalculation([FromQuery] CarCostCalculationRequest request)
    {
        EitherResult<CarCostCalculationResponse, Exception> result = handler.Handle(request);

        return result.Match(
            calculation => Ok(calculation),
            error => Problem(error.Message));
    }
}