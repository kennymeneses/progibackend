using BidCalculation.Application.CalculationRules.V1.FeeCalculations.Interfaces;
using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules.V1.FeeCalculations;

public sealed class AssociationCalculationFee : DecoratorFee, ISingleFee 
{
    public AssociationCalculationFee(BaseCarCalculationCost baseCalculation) : base(baseCalculation)
    {
    }
    
    public double CalculatedFee { get; set; }
    
    public override double AddCalculationFee(CarCostCalculationRequest request)
    {
        CalculatedFee = 
            request.CarCost switch
            { 
                >= CalculationConstants.MinMountFirstRange and <= CalculationConstants.MaxMountFirstRange 
                    => CalculationConstants.FirstRangeAssociationFee,
                > CalculationConstants.MaxMountFirstRange and <= CalculationConstants.MaxMountSecondRange 
                    => CalculationConstants.SecondRangeAssociationFee,
                > CalculationConstants.MaxMountSecondRange and <= CalculationConstants.MaxMountThirdRange 
                    => CalculationConstants.ThirdRangeAssociationFee,
                _ => CalculationConstants.FourthRangeAssociationFee
            };
        
        return base.AddCalculationFee(request) + CalculatedFee;
    }
}