using BidCalculation.Application.Models.V1.Enums;
using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules.V1.FeeCalculations;

public class SellerCalculationFee : DecoratorFee
{
    public SellerCalculationFee(BaseCarCalculationCost baseCalculation) : base(baseCalculation)
    {
    }
    
    public override double AddCalculationFee(CarCostCalculationRequest request)
    {
        double sellerPercentage = request.Type == VehicleType.Luxury ? CalculationConstants.SellerCarLuxuryFee : CalculationConstants.SellerCarCommonFee;

        var a = base.AddCalculationFee(request) + (request.CarCost * sellerPercentage);
        
        Console.WriteLine("SellerCalculation: " + a);
        
        return base.AddCalculationFee(request) + (request.CarCost * sellerPercentage);
    }
}