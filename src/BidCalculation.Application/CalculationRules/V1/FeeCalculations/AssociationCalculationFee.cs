using BidCalculation.Application.Configuration;
using BidCalculation.Application.Models.V1.Requests;
using Constants = BidCalculation.Application.CalculationRules.CalculationConstants;

namespace BidCalculation.Application.CalculationRules.V1.FeeCalculations;

public sealed class AssociationCalculationFee : DecoratorFee
{
    public AssociationCalculationFee(BaseCarCalculationCost baseCalculation) : base(baseCalculation)
    {
    }
    
    public override double CalculatedFee { get; protected set; }
    
    public override EitherResult<double,Exception> AddCalculationFee(CarCostCalculationRequest request)
    {
        CalculatedFee = 
            request.CarCost switch
            { 
                >= Constants.MinMountFirstRange and <= Constants.MaxMountFirstRange 
                    => Constants.FirstRangeAssociationFee,
                > Constants.MaxMountFirstRange and <= Constants.MaxMountSecondRange 
                    => Constants.SecondRangeAssociationFee,
                > Constants.MaxMountSecondRange and <= Constants.MaxMountThirdRange 
                    => Constants.ThirdRangeAssociationFee,
                _ => Constants.FourthRangeAssociationFee
            };
        
        return base.AddCalculationFee(request).Value + CalculatedFee;
    }
}