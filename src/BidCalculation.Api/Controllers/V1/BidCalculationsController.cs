using BidCalculation.Application.Handlers.V1.Interfaces;
using BidCalculation.Application.Models.V1.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.Api.Controllers.V1;

public class BidCalculationsController(ICarCostCalculationHandler handler) : BaseController
{
    [HttpGet]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public IActionResult GetCalculation([FromQuery] CarCostCalculationRequest request)
    {
        double result = handler.Handle(request);
        
        return Ok(result);
    }
}