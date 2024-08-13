using BidCalculation.Application.Configuration;
using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules.V1.FeeCalculations;

public abstract class DecoratorFee(BaseCarCalculationCost baseCalculation) : BaseCarCalculationCost
{
    private decimal _calculatedFee;
    
    public virtual decimal CalculatedFee
    {
        get => Math.Round(_calculatedFee, 2);
        protected set => _calculatedFee = value;
    }

    public virtual void Initialize()
    {
        CalculatedFee = 0;
    }
    
    public override EitherResult<decimal,Exception> AddCalculationFee(CarCostCalculationRequest request)
    {
        return baseCalculation.AddCalculationFee(request);
    }
}