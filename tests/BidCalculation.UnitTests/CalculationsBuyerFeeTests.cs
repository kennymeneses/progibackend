using BidCalculation.Application.CalculationRules;
using BidCalculation.Application.CalculationRules.V1.FeeCalculations;
using BidCalculation.Application.Models.V1.Enums;
using BidCalculation.Application.Models.V1.Requests;
using FluentAssertions;
using NSubstitute;

namespace BidCalculation.UnitTests;

public class CalculationsBuyerFeeTests
{
    private readonly BaseCarCalculationCost _baseCarCalculationCost;
    private readonly DecoratorFee _decoratorFee;
    private readonly BuyerCalculationFee _sut;

    public CalculationsBuyerFeeTests()
    {
        _baseCarCalculationCost = Substitute.For<BaseCarCalculationCost>();
        _decoratorFee = Substitute.For<DecoratorFee>(_baseCarCalculationCost);
        _sut = new BuyerCalculationFee(_baseCarCalculationCost);
    }

    [Fact]
    public void It_ShouldReturnBuyerFeeSuccessfully_WhenRequestHasCommonTypeAnd()
    {
        var request = new CarCostCalculationRequest
        {
            CarCost = 501,
            Type = VehicleType.Common
        };

        _baseCarCalculationCost.AddCalculationFee(request).Returns(501);

        var result = _sut.AddCalculationFee(request);

        result.Value.Should().NotBe(50);
        result.IsError.Should().BeFalse();
        result.Value.Should().Be(551);
    }

    [Fact]
    public void It_ShouldReturnError_WhenCalculationConstantIsInvalid()
    {
        CarCostCalculationRequest request = null;
        
        _baseCarCalculationCost.AddCalculationFee(request).Returns(501);
        
        var result = _sut.AddCalculationFee(request);

        result.IsError.Should().BeTrue();
        result.Should().NotBeNull();
    }
}