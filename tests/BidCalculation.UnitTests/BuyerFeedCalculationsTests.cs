using BidCalculation.Application.CalculationRules;
using BidCalculation.Application.CalculationRules.V1.FeeCalculations;
using NSubstitute;

namespace BidCalculation.UnitTests;

public class BuyerFeedCalculationsTests
{
    private readonly BaseCarCalculationCost _baseCarCalculationCost;
    private readonly BuyerCalculationFee _sut;

    public BuyerFeedCalculationsTests()
    {
        _baseCarCalculationCost = Substitute.For<BaseCarCalculationCost>();
    }
}