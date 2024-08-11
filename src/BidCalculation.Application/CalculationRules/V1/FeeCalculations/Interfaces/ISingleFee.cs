namespace BidCalculation.Application.CalculationRules.V1.FeeCalculations.Interfaces;

public interface ISingleFee
{
    public double CalculatedFee { get; protected set; }
}