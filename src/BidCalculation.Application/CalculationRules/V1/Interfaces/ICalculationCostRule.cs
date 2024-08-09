using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules.V1.Interfaces;

public interface ICalculationCostRule
{
    double GetSubTotal(CarCostCalculationRequest request);
}