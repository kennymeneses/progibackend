namespace BidCalculation.Application.CalculationRules;

public static class CalculationConstants
{
    #region BasicBuyerFeeValues
    
    public const double AverageBuyerBaseFee = 0.1;
    public const double MinCommonCarBaseFee = 10;
    public const double MaxCommonCarBaseFee = 50;
    public const double MinLuxuryCarBaseFee = 25;
    public const double MaxLuxuryCarBaseFee = 200;
    
    #endregion

    
    #region SellerSpecialFeeValues
    
    public const double SellerCarCommonFee = 0.02;
    public const double SellerCarLuxuryFee = 0.04;
    
    #endregion
    
    
    #region AssociationFeeValues
    
    public const double MinMountFirstRange = 1;
    public const double MaxMountFirstRange = 500;
    public const double MaxMountSecondRange = 1000;
    public const double MaxMountThirdRange = 3000;

    public const double FirstRangeAssociationFee = 5;
    public const double SecondRangeAssociationFee = 10;
    public const double ThirdRangeAssociationFee = 15;
    public const double FourthRangeAssociationFee = 20;
    
    #endregion

    
    public const double StorageFee = 100;
}

public static class ConfigurationConstants
{
    #region SwaggerValuesConfiguration
    
    public const int DefaultApiVersion = 1;
    public const int MinorApiVersion = 0;
    public const string GroupNameFormat = "'v'VVV";
    public const string SwaggerJsonEndpoint = "/swagger/{0}/swagger.json";
    
    #endregion
}