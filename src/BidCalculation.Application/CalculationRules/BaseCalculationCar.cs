using BidCalculation.Application.Configuration;
using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules;

public class BaseCalculationCar : BaseCarCalculationCost
{
    public override EitherResult<decimal,Exception> AddCalculationFee(CarCostCalculationRequest request)
    {
        return request.CarCost.ToDecimal();
    }
}