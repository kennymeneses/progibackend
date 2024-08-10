using BidCalculation.Application.CalculationRules.V1.Interfaces;
using BidCalculation.Application.Models.V1.Requests;

namespace BidCalculation.Application.CalculationRules.V1;

public class AssociationFeeRule: ICalculationFeeRule
{
    public double GetFeeCalculation(CarCostCalculationRequest request)
    {
        return request.CarCost switch
        { 
            >= CalculationConstants.MinMountFirstRange and <= CalculationConstants.MaxMountFirstRange 
                => CalculationConstants.FirstRangeAssociationFee,
            > CalculationConstants.MaxMountFirstRange and <= CalculationConstants.MaxMountSecondRange 
                => CalculationConstants.SecondRangeAssociationFee,
            > CalculationConstants.MaxMountSecondRange and <= CalculationConstants.MaxMountThirdRange 
                => CalculationConstants.ThirdRangeAssociationFee,
            _ => CalculationConstants.FourthRangeAssociationFee
        };
    }
}