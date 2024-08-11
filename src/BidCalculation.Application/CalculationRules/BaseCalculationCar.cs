using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules;

public class BaseCalculationCar : BaseCarCalculationCost
{
    public override double AddCalculationFee(CarCostCalculationRequest request)
    {
        return request.CarCost;
    }
}