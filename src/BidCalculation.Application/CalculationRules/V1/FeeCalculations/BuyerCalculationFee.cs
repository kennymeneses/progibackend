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
        double initialSubtotal = CalculationConstants.AverageBuyerBaseFee * request.CarCost;
        
        double basicBuyerFee = request.Type is VehicleType.Luxury
            ? Math.Clamp(initialSubtotal, CalculationConstants.MinLuxuryCarBaseFee, CalculationConstants.MaxLuxuryCarBaseFee)
            : Math.Clamp(initialSubtotal, CalculationConstants.MinCommonCarBaseFee, CalculationConstants.MaxCommonCarBaseFee);

        var a = base.AddCalculationFee(request) + basicBuyerFee;
        Console.WriteLine("BuyerCalculation: " + a);
        

        return base.AddCalculationFee(request) + basicBuyerFee;
    }
}