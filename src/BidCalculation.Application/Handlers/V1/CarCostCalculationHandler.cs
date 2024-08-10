using BidCalculation.Application.CalculationRules;
using BidCalculation.Application.CalculationRules.V1.FeeCalculations;
using BidCalculation.Application.Handlers.V1.Interfaces;
using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.Handlers.V1;

public class CarCostCalculationHandler : ICarCostCalculationHandler
{
    public double GetTotalCost(CarCostCalculationRequest request)
    {
        CarBidCalculation baseCarPrice = new CarBidCalculation();
        var buyerFeeDecorator = new BuyerCalculationFee(baseCarPrice);
        var sellerFeeDecorator = new SellerCalculationFee(buyerFeeDecorator);
        var associationFeeDecorator = new AssociationCalculationFee(sellerFeeDecorator);
        associationFeeDecorator.AddCalculationFee(request);
        
        return associationFeeDecorator.AddCalculationFee(request) + CalculationConstants.StorageFee;
    }
}