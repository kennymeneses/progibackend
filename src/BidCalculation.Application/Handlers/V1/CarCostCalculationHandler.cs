using BidCalculation.Application.CalculationRules;
using BidCalculation.Application.CalculationRules.V1.FeeCalculations;
using BidCalculation.Application.Configuration;
using BidCalculation.Application.Handlers.V1.Interfaces;
using BidCalculation.Application.Models.V1.Requests;
using BidCalculation.Application.Models.V1.Responses;

namespace BidCalculation.Application.Handlers.V1;

public sealed class CarCostCalculationHandler : ICarCostCalculationHandler
{
    public EitherResult<CarCostCalculationResponse, Exception> Handle(CarCostCalculationRequest request)
    {
        if (request.CarCost < 1)
        {
            return new EitherResult<CarCostCalculationResponse, Exception>(new InvalidOperationException(CalculationConstants.InvalidBaseCarPrice));
        }
        
        var baseCarPrice = new BaseCalculationCar();
        var buyerFeeDecorator = new BuyerCalculationFee(baseCarPrice);
        var sellerFeeDecorator = new SellerCalculationFee(buyerFeeDecorator);
        var associationFeeDecorator = new AssociationCalculationFee(sellerFeeDecorator);
        
        return new EitherResult<CarCostCalculationResponse, Exception>(new CarCostCalculationResponse()
        {
            Total = associationFeeDecorator.AddCalculationFee(request) + CalculationConstants.StorageFee,
            BasicBuyerFee = buyerFeeDecorator.CalculatedFee,
            SellerSpecialFee = sellerFeeDecorator.CalculatedFee,
            AssociationFee = associationFeeDecorator.CalculatedFee
        });
    }
}