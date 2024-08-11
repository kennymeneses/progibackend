using BidCalculation.Application.Configuration;
using BidCalculation.Application.Models.V1.Enums;
using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules.V1.FeeCalculations;

public sealed class BuyerCalculationFee : DecoratorFee
{
    public BuyerCalculationFee(BaseCarCalculationCost baseCalculation) : base(baseCalculation)
    {
    }
    
    public override double CalculatedFee { get; protected set; }
    
    public override EitherResult<double,Exception> AddCalculationFee(CarCostCalculationRequest request)
    {
        if (request is null)
        {
            return new ArgumentNullException();
        }
        
        double buyerFeeCalculated = CalculationConstants.AverageBuyerBaseFee * request.CarCost;
        
        CalculatedFee = request.Type is VehicleType.Luxury
            ? Math.Clamp(buyerFeeCalculated, CalculationConstants.MinLuxuryCarBaseFee, CalculationConstants.MaxLuxuryCarBaseFee)
            : Math.Clamp(buyerFeeCalculated, CalculationConstants.MinCommonCarBaseFee, CalculationConstants.MaxCommonCarBaseFee);
        
        return (base.AddCalculationFee(request).Value + CalculatedFee);
    }
}