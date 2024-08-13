using Constants = BidCalculation.Application.CalculationRules.CalculationConstants;

namespace BidCalculation.Application.Configuration;

public static class ExtensionMethods
{
    public static EitherResult<decimal, Exception> ToDecimal(this double value)
    {
        decimal roundedValue = Math.Round((decimal)value, Constants.DecimalCount);
        
        string doubleFormatted = roundedValue.ToString(Constants.NumericFormat);
        
        if (decimal.TryParse(doubleFormatted, out var decimalValue))
        {
            return decimalValue;
        }

        return new FormatException(Constants.FormatErrorMessage);
    }
}