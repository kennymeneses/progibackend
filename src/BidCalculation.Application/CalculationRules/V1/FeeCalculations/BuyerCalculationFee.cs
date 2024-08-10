using BidCalculation.Application.Models.V1.Enums;
using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules.V1.FeeCalculations;

public class BuyerCalculationFee : DecoratorFee
{
    public BuyerCalculationFee(BaseCarCalculationCost baseCalculation) : base(baseCalculation)
    {
    }

    public override double AddCalculationFee(CarCostCalculationRequest request)
    {
        double buyerFeeCalculated = CalculationConstants.AverageBuyerBaseFee * request.CarCost;
        
        double basicBuyerFee = request.Type is VehicleType.Luxury
            ? Math.Clamp(buyerFeeCalculated, CalculationConstants.MinLuxuryCarBaseFee, CalculationConstants.MaxLuxuryCarBaseFee)
            : Math.Clamp(buyerFeeCalculated, CalculationConstants.MinCommonCarBaseFee, CalculationConstants.MaxCommonCarBaseFee);

        return base.AddCalculationFee(request) + basicBuyerFee;
    }
}