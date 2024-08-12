using BidCalculation.Application.CalculationRules;
using BidCalculation.Application.CalculationRules.V1.FeeCalculations;
using FluentAssertions;
using NSubstitute;
using Helper = BidCalculation.TestHelper.TestHelper;
using Constants = BidCalculation.TestHelper.HelperConstants;

namespace BidCalculation.UnitTests;

public class CalculationSellerFeeTests
{
    private readonly BaseCarCalculationCost _baseCarCalculationCost;
    private readonly SellerCalculationFee _sut;

    public CalculationSellerFeeTests()
    {
        _baseCarCalculationCost = Substitute.For<BaseCarCalculationCost>();
        _sut = new SellerCalculationFee(_baseCarCalculationCost);
    }

    [Fact]
    public void It_ShouldReturnSellerFeeSuccessfully_WhenRequestHasCommonType()
    {
        _baseCarCalculationCost.AddCalculationFee(Helper.CommonCalculationRequest()).Returns(Constants.CommonVehiclePrice);
        
        var result = _sut.AddCalculationFee(Helper.CommonCalculationRequest());
        
        result.IsError.Should().BeFalse();
        result.Value.Should().Be(Constants.CommonSpecialFee);
    }
    
    [Fact]
    public void It_ShouldReturnSellerFeeSuccessfully_WhenRequestHasLuxuryType()
    {
        _baseCarCalculationCost.AddCalculationFee(Helper.LuxuryCalculationRequest()).Returns(Constants.LuxuryVehiclePrice);
        
        var result = _sut.AddCalculationFee(Helper.LuxuryCalculationRequest());
        
        result.IsError.Should().BeFalse();
        result.Value.Should().Be(Constants.LuxurySpecialFee);
    }
}