using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules;

public class CarBidCalculation : BaseCarCalculationCost
{
    public override double AddCalculationFee(CarCostCalculationRequest request)
    {
        return request.CarCost;
    }
}