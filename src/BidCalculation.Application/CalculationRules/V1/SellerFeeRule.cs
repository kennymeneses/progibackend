using BidCalculation.Application.CalculationRules.V1.Interfaces;
using BidCalculation.Application.Models.V1.Enums;
using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules.V1;

public class SellerFeeRule : ICalculationCostRule
{
    public double GetSubTotal(CarCostCalculationRequest request)
    {
        double sellerPercentage = request.Type == VehicleType.Luxury ? 0.04 : 0.02;

        return request.CarCost * sellerPercentage;
    }
}