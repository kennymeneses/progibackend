using BidCalculation.Application.Configuration;
using BidCalculation.Application.Models.V1.Enums;
using BidCalculation.Application.Models.V1.Requests;
using Constants = BidCalculation.Application.CalculationRules.CalculationConstants;

namespace BidCalculation.Application.CalculationRules.V1.FeeCalculations;

public sealed class SellerCalculationFee : DecoratorFee
{
    public SellerCalculationFee(BaseCarCalculationCost baseCalculation) : base(baseCalculation)
    {
    }
    
    public override EitherResult<decimal,Exception> AddCalculationFee(CarCostCalculationRequest request)
    {
        decimal feePercentage = request.Type == VehicleType.Luxury ? Constants.LuxurySellerFee : Constants.CommonSellerFee;
        
        CalculatedFee = request.CarCost.ToDecimal().Value * feePercentage;
        
        return base.AddCalculationFee(request).Value + CalculatedFee;
    }
}