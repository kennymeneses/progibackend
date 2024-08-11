namespace BidCalculation.Application.Models.V1.Responses;

public sealed record CarCostCalculationResponse
{
    public double Total { get; init; }
    public double BasicBuyerFee { get; init; }
    public double SellerSpecialFee { get; init; }
    public double AssociationFee { get; init; }
}