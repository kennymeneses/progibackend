using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.Handlers.V1.Interfaces;

public interface ICarCostCalculationHandler
{
    double Handle(CarCostCalculationRequest request);
}