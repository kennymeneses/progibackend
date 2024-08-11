using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules.V1.FeeCalculations;

public abstract class DecoratorFee(BaseCarCalculationCost baseCalculation) : BaseCarCalculationCost
{
    public override double AddCalculationFee(CarCostCalculationRequest request)
    {
        return baseCalculation.AddCalculationFee(request);
    }
}