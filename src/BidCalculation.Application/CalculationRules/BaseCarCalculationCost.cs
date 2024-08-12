using BidCalculation.Application.Configuration;
using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules;

public abstract class BaseCarCalculationCost
{
    public abstract EitherResult<double,Exception> AddCalculationFee(CarCostCalculationRequest request);
}