using BidCalculation.Application.CalculationRules;
using BidCalculation.Application.CalculationRules.V1.FeeCalculations;
using FluentAssertions;
using NSubstitute;
using Helper = BidCalculation.TestHelper.TestHelper;
using Constants = BidCalculation.TestHelper.HelperConstants;

namespace BidCalculation.UnitTests;

public class CalculationAssociationFeeTests
{
    private readonly BaseCarCalculationCost _baseCarCalculationCost;
    private readonly AssociationCalculationFee _sut;

    public CalculationAssociationFeeTests()
    {
        _baseCarCalculationCost = Substitute.For<BaseCarCalculationCost>();
        _sut = new AssociationCalculationFee(_baseCarCalculationCost);
    }

    [Fact]
    public void It_ShouldReturnBuyerFeeSuccessfully_WhenRequestHasCommonType()
    {
        _baseCarCalculationCost.AddCalculationFee(Helper.CommonCalculationRequest()).Returns(Constants.CommonVehiclePrice);
        
        var result = _sut.AddCalculationFee(Helper.CommonCalculationRequest());
        
        result.IsError.Should().BeFalse();
        result.Value.Should().Be(Constants.CommonAssociationFee);
    }
    
    [Fact]
    public void It_ShouldReturnBuyerFeeSuccessfully_WhenRequestHasLuxuryType()
    {
        _baseCarCalculationCost.AddCalculationFee(Helper.LuxuryCalculationRequest()).Returns(Constants.LuxuryVehiclePrice);
        
        var result = _sut.AddCalculationFee(Helper.LuxuryCalculationRequest());
        
        result.IsError.Should().BeFalse();
        result.Value.Should().Be(Constants.LuxuryAssociationFee);
    }
}