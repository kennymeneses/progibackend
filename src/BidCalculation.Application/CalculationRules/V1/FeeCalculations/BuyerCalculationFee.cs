using BidCalculation.Application.CalculationRules.V1.FeeCalculations.Interfaces;
using BidCalculation.Application.Models.V1.Enums;
using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules.V1.FeeCalculations;

public sealed class BuyerCalculationFee : DecoratorFee, ISingleFee
{
    public BuyerCalculationFee(BaseCarCalculationCost baseCalculation) : base(baseCalculation)
    {
    }
    
    public double CalculatedFee { get; set; }
    public override double AddCalculationFee(CarCostCalculationRequest request)
    {
        double buyerFeeCalculated = CalculationConstants.AverageBuyerBaseFee * request.CarCost;
        
        CalculatedFee = request.Type is VehicleType.Luxury
            ? Math.Clamp(buyerFeeCalculated, CalculationConstants.MinLuxuryCarBaseFee, CalculationConstants.MaxLuxuryCarBaseFee)
            : Math.Clamp(buyerFeeCalculated, CalculationConstants.MinCommonCarBaseFee, CalculationConstants.MaxCommonCarBaseFee);
        
        return base.AddCalculationFee(request) + CalculatedFee;
    }


}