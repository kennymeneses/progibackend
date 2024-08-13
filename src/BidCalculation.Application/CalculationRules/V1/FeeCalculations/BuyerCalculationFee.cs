using BidCalculation.Application.Configuration;
using BidCalculation.Application.Models.V1.Enums;
using BidCalculation.Application.Models.V1.Requests;
using Constants = BidCalculation.Application.CalculationRules.CalculationConstants;

namespace BidCalculation.Application.CalculationRules.V1.FeeCalculations;

public sealed class BuyerCalculationFee : DecoratorFee
{
    public BuyerCalculationFee(BaseCarCalculationCost baseCalculation) : base(baseCalculation)
    {
    }
    
    public override EitherResult<decimal,Exception> AddCalculationFee(CarCostCalculationRequest request)
    {
        double buyerFeeCalculated = Constants.AverageBuyerBaseFee * request.CarCost;
        
        CalculatedFee = request.Type is VehicleType.Luxury
            ? Math.Clamp(buyerFeeCalculated, Constants.MinLuxuryBaseFee, Constants.MaxLuxuryBaseFee).ToDecimal().Value
            : Math.Clamp(buyerFeeCalculated, Constants.MinCommonBaseFee, Constants.MaxCommonBaseFee).ToDecimal().Value;
        
        return (base.AddCalculationFee(request).Value + CalculatedFee);
    }
}