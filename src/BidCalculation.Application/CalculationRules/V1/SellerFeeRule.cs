using BidCalculation.Application.CalculationRules.V1.Interfaces;
using BidCalculation.Application.Models.V1.Enums;
using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules.V1;

public class SellerFeeRule : ICalculationFeeRule
{
    public double GetFeeCalculation(CarCostCalculationRequest request)
    {
        double sellerPercentage = request.Type == VehicleType.Luxury ? CalculationConstants.SellerCarLuxuryFee : CalculationConstants.SellerCarCommonFee;

        return request.CarCost * sellerPercentage;
    }
}