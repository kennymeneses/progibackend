namespace BidCalculation.TestHelper;

public static class HelperConstants
{
    #region CommonVehicleRequest

    public const double CommonVehiclePrice = 1100;
    public const decimal CommonVehiclePriceD = 1100m;
    public const decimal CommonBasicFee = 1150m;
    public const decimal CommonSpecialFee = 1122m;
    public const decimal CommonAssociationFee = 1115m;
    public const decimal CommonTotalPrice = 1287m;

    #endregion
    
    
    #region LuxuryVehicleRequest
    
    public const double LuxuryVehiclePrice = 1800;
    public const decimal LuxuryVehiclePriceD = 1800m;
    public const decimal LuxuryBasicFee = 1980m;
    public const decimal LuxurySpecialFee = 1872m;
    public const decimal LuxuryAssociationFee = 1815m;

    #endregion
    
    #region ApiTestParam

    public const string CalculationFeesUrl = "api/v1/BidCalculations";
    public const string TestEnvName = "test";

    #endregion
}