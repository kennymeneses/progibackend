using BidCalculation.Application.CalculationRules;
using BidCalculation.Application.CalculationRules.V1.FeeCalculations;
using BidCalculation.Application.Handlers.V1.Interfaces;
using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.Handlers.V1;

public class CarCostCalculationHandler : ICarCostCalculationHandler
{
    public double GetTotalCost(CarCostCalculationRequest request)
    {
        CarBidCalculation calculation = new CarBidCalculation();
        var decoratorFeeA = new BuyerCalculationFee(calculation);
        var decoratorFeeB = new SellerCalculationFee(decoratorFeeA);
        var decoratorFeeC = new AssociationCalculationFee(decoratorFeeB);
        decoratorFeeC.AddCalculationFee(request);
        
        Console.WriteLine(decoratorFeeC.AddCalculationFee(request));
        
        return decoratorFeeC.AddCalculationFee(request) + 100;
    }
}