using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules.V1.Interfaces;

public interface ICalculationFeeRule
{
    double GetFeeCalculation(CarCostCalculationRequest request);
}