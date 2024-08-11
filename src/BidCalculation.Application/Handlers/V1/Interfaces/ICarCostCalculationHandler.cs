using BidCalculation.Application.Configuration;
using BidCalculation.Application.Models.V1.Requests;
using BidCalculation.Application.Models.V1.Responses;

namespace BidCalculation.Application.Handlers.V1.Interfaces;

public interface ICarCostCalculationHandler
{
    EitherResult<CarCostCalculationResponse, Exception> Handle(CarCostCalculationRequest request);
}