using BidCalculation.Application.CalculationRules;
using BidCalculation.Application.CalculationRules.V1.FeeCalculations;
using BidCalculation.Application.Configuration;
using BidCalculation.Application.Handlers.V1.Interfaces;
using BidCalculation.Application.Models.V1.Requests;
using BidCalculation.Application.Models.V1.Responses;
using Constants = BidCalculation.Application.CalculationRules.CalculationConstants;

namespace BidCalculation.Application.Handlers.V1;

public sealed class CarCostCalculationHandler : ICarCostCalculationHandler
{
    public EitherResult<CarCostCalculationResponse, Exception> Handle(CarCostCalculationRequest request)
    {
        if (request.CarCost < Constants.MinValidCarPrice)
        {
            return new InvalidOperationException(Constants.InvalidBaseCarPrice);
        }
        
        var baseCarPrice = new BaseCalculationCar();
        var buyerFeeDecorator = new BuyerCalculationFee(baseCarPrice);
        var sellerFeeDecorator = new SellerCalculationFee(buyerFeeDecorator);
        var associationFeeDecorator = new AssociationCalculationFee(sellerFeeDecorator);
        
        return new CarCostCalculationResponse()
        {
            Total = associationFeeDecorator.AddCalculationFee(request).Value + Constants.StorageFee,
            BasicBuyerFee = buyerFeeDecorator.CalculatedFee,
            SellerSpecialFee = sellerFeeDecorator.CalculatedFee,
            AssociationFee = associationFeeDecorator.CalculatedFee
        };
    }
}