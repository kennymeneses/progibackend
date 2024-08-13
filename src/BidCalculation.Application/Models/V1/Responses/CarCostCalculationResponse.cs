namespace BidCalculation.Application.Models.V1.Responses;

public sealed record CarCostCalculationResponse
{
    public decimal Total { get; init; }
    public decimal BasicBuyerFee { get; init; }
    public decimal SellerSpecialFee { get; init; }
    public decimal AssociationFee { get; init; }
}