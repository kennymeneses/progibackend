using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules;

public abstract class BaseCarCalculationCost
{
    public abstract double AddCalculationFee(CarCostCalculationRequest request);
}