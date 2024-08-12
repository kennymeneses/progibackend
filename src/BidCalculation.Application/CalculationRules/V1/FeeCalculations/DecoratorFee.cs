using BidCalculation.Application.Configuration;
using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules.V1.FeeCalculations;

public abstract class DecoratorFee(BaseCarCalculationCost baseCalculation) : BaseCarCalculationCost
{
    public virtual double CalculatedFee { get; protected set; }
    
    public override EitherResult<double,Exception> AddCalculationFee(CarCostCalculationRequest request)
    {
        return baseCalculation.AddCalculationFee(request);
    }
}