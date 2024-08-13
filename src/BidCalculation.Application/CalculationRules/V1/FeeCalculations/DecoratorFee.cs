using BidCalculation.Application.Configuration;
using BidCalculation.Application.Models.V1.Requests;
using Constants = BidCalculation.Application.CalculationRules.CalculationConstants;

namespace BidCalculation.Application.CalculationRules.V1.FeeCalculations;

public abstract class DecoratorFee(BaseCarCalculationCost baseCalculation) : BaseCarCalculationCost
{
    private decimal _calculatedFee;
    
    public virtual decimal CalculatedFee
    {
        get => Math.Round(_calculatedFee, Constants.DecimalCount);
        protected set => _calculatedFee = value;
    }

    public virtual void Initialize()
    {
        CalculatedFee = Constants.InitialCalculatedFee;
    }
    
    public override EitherResult<decimal,Exception> AddCalculationFee(CarCostCalculationRequest request)
    {
        return baseCalculation.AddCalculationFee(request);
    }
}