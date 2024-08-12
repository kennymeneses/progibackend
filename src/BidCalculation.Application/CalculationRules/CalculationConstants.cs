namespace BidCalculation.Application.CalculationRules;

public static class CalculationConstants
{
    #region BasicBuyerFeeValues
    
    public const double AverageBuyerBaseFee = 0.1;
    public const double MinCommonBaseFee = 10;
    public const double MaxCommonBaseFee = 50;
    public const double MinLuxuryBaseFee = 25;
    public const double MaxLuxuryBaseFee = 200;
    
    #endregion

    
    #region SellerSpecialFeeValues
    
    public const double CommonSellerFee = 0.02;
    public const double LuxurySellerFee = 0.04;
    
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
    
    
    #region CalculationErrorMessages

    public const string InvalidBaseCarPrice = "The vehicle cost is not valid.";

    #endregion
}