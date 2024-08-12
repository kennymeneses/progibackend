namespace BidCalculation.TestHelper;

public static class HelperConstants
{
    #region CommonVehicleRequest

    public const double CommonVehiclePrice = 1100;
    public const double CommonBasicFee = 1150;
    public const double CommonSpecialFee = 1122;
    public const double CommonAssociationFee = 1115;
    public const double CommonTotalPrice = 1287;

    #endregion
    
    
    #region LuxuryVehicleRequest
    
    public const double LuxuryVehiclePrice = 1800;
    public const double LuxuryBasicFee = 1980;
    public const double LuxurySpecialFee = 1872;
    public const double LuxuryAssociationFee = 1815;

    #endregion
    
    #region ApiTestParam

    public const string CalculationFeesUrl = "api/v1/BidCalculations";
    public const string TestEnvName = "test";

    #endregion
}