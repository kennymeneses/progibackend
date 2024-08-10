using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules.V1.FeeCalculations;

public class AssociationCalculationFee : DecoratorFee
{
    public AssociationCalculationFee(BaseCarCalculationCost baseCalculation) : base(baseCalculation)
    {
    }

    public override double AddCalculationFee(CarCostCalculationRequest request)
    {
        double associationFee = 
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
        
        return base.AddCalculationFee(request) + associationFee;
    }
}