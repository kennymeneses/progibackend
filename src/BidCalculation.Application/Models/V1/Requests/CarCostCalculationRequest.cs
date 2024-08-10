using BidCalculation.Application.Models.V1.Enums;

namespace BidCalculation.Application.Models.V1.Requests;

public class CarCostCalculationRequest
{
    public required double CarCost { get; init; }

    public required VehicleType Type { get; init; }
}

