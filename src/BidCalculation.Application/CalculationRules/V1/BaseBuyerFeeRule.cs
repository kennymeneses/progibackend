using BidCalculation.Application.CalculationRules.V1.Interfaces;
using BidCalculation.Application.Models.V1.Enums;
using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules.V1;

public class BaseBuyerFeeRule : ICalculationFeeRule
{
    public double GetFeeCalculation(CarCostCalculationRequest request)
    {
        double initialSubtotal = CalculationConstants.AverageBuyerBaseFee * request.CarCost;
        
        return request.Type is VehicleType.Luxury
            ? Math.Clamp(initialSubtotal, CalculationConstants.MinLuxuryCarBaseFee, CalculationConstants.MaxLuxuryCarBaseFee)
            : Math.Clamp(initialSubtotal, CalculationConstants.MinCommonCarBaseFee, CalculationConstants.MaxCommonCarBaseFee);
    }
}