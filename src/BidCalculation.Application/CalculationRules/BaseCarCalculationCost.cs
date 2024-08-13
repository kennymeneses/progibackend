using BidCalculation.Application.Configuration;
using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules;

public abstract class BaseCarCalculationCost
{
    public abstract EitherResult<decimal,Exception> AddCalculationFee(CarCostCalculationRequest request);
}