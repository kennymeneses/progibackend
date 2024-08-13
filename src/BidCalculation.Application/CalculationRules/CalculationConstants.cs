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
    
    public const decimal CommonSellerFee = 0.02m;
    public const decimal LuxurySellerFee = 0.04m;
    
    #endregion
    
    
    #region AssociationFeeValues
    
    public const double MinMountFirstRange = 1;
    public const double MaxMountFirstRange = 500;
    public const double MaxMountSecondRange = 1000;
    public const double MaxMountThirdRange = 3000;

    public const decimal FirstRangeAssociationFee = 5.00m;
    public const decimal SecondRangeAssociationFee = 10.00m;
    public const decimal ThirdRangeAssociationFee = 15.00m;
    public const decimal FourthRangeAssociationFee = 20.00m;
    
    public const decimal StorageFee = 100;
    
    #endregion
    
    
    #region MathRoundConfiguration

    public const int InitialCalculatedFee = 0;
    public const int DecimalCount = 2;
    public const string NumericFormat = "F2";
    
    #endregion
    
    
    #region CalculationErrorMessages

    public const string InvalidBaseCarPrice = "The vehicle cost is not valid.";
    public const string FormatErrorMessage = "The value cant be format as decimal";

    #endregion
}