using BidCalculation.Application.CalculationRules.V1.FeeCalculations.Interfaces;
using BidCalculation.Application.Models.V1.Enums;
using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules.V1.FeeCalculations;

public sealed class SellerCalculationFee : DecoratorFee, ISingleFee
{
    public SellerCalculationFee(BaseCarCalculationCost baseCalculation) : base(baseCalculation)
    {
    }
    
    public double CalculatedFee { get; set; }
    
    public override double AddCalculationFee(CarCostCalculationRequest request)
    {
        double feePercentage = request.Type == VehicleType.Luxury ? CalculationConstants.SellerCarLuxuryFee : CalculationConstants.SellerCarCommonFee;
        
        CalculatedFee = request.CarCost * feePercentage;
        
        return base.AddCalculationFee(request) + CalculatedFee;
    }
}