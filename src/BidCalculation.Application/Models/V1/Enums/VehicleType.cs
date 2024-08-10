namespace BidCalculation.Application.Models.V1.Enums;

/// <summary>
/// Whether the user car selection is a common or luxury car.
/// </summary>
public enum VehicleType
{
    /// <summary>
    /// The user has chosen a common car to calculate.
    /// </summary>
    Common,
    
    /// <summary>
    /// The user has chosen a luxury car to calculate.
    /// </summary>
    Luxury
}