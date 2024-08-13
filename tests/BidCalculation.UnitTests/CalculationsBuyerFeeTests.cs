using BidCalculation.Application.CalculationRules;
using BidCalculation.Application.CalculationRules.V1.FeeCalculations;
using BidCalculation.Application.Configuration;
using FluentAssertions;
using NSubstitute;
using Helper = BidCalculation.TestHelper.TestHelper;
using Constants = BidCalculation.TestHelper.HelperConstants;

namespace BidCalculation.UnitTests;

public class CalculationsBuyerFeeTests
{
    private readonly BaseCarCalculationCost _baseCarCalculationCost;
    private readonly BuyerCalculationFee _sut;

    public CalculationsBuyerFeeTests()
    {
        _baseCarCalculationCost = Substitute.For<BaseCarCalculationCost>();
        _sut = new BuyerCalculationFee(_baseCarCalculationCost);
    }

    [Fact]
    public void It_ShouldReturnBuyerFeeSuccessfully_WhenRequestHasCommonType()
    {
        _baseCarCalculationCost.AddCalculationFee(Helper.CommonCalculationRequest()).Returns(Constants.CommonVehiclePriceD);

        var result = _sut.AddCalculationFee(Helper.CommonCalculationRequest());
        
        result.IsError.Should().BeFalse();
        result.Value.Should().Be(Constants.CommonBasicFee);
    }
    
    [Fact]
    public void It_ShouldReturnBuyerFeeSuccessfully_WhenRequestHasLuxuryType()
    {
        _baseCarCalculationCost.AddCalculationFee(Helper.LuxuryCalculationRequest()).Returns(Constants.LuxuryVehiclePriceD);

        var result = _sut.AddCalculationFee(Helper.LuxuryCalculationRequest());
        
        result.IsError.Should().BeFalse();
        result.Value.Should().Be(Constants.LuxuryBasicFee);
    }
}