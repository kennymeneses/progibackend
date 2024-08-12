using System.Net;
using System.Net.Http.Json;
using BidCalculation.Application.CalculationRules;
using BidCalculation.Application.Models.V1.Requests;
using BidCalculation.Application.Models.V1.Responses;
using BidCalculation.IntegrationTests.Helpers;
using BidCalculation.TestHelper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Helper = BidCalculation.TestHelper.TestHelper;
using Constants = BidCalculation.TestHelper.HelperConstants;

namespace BidCalculation.IntegrationTests;

public class FeeCalculationsTests : IClassFixture<BidCalculationApiFactory>
{
    private readonly HttpClient _client;
    
    public FeeCalculationsTests(BidCalculationApiFactory bidCalculationApiFactory)
    {
        _client = bidCalculationApiFactory.HttpClient;
    }
    
    [Fact]
    public async Task CalculateTotalCost_WhenRequestIsValid_ShouldReturnCalculationResponse()
    {
        CarCostCalculationResponse response =
            await _client.Create<CarCostCalculationRequest, CarCostCalculationResponse>(Constants.CalculationFeesUrl, Helper.CommonCalculationRequest());
        
        response.Should().NotBeNull();
        response.Total.Should().Be(Constants.CommonTotalPrice);
    }

    [Fact]
    public async Task CalculateTotalCost_WhenCarCostIsMinorThanOne_ShouldReturnError()
    {
        HttpResponseMessage httpResponseMessage = 
            await _client.PostAsJsonAsync(Constants.CalculationFeesUrl, Helper.InvalidCalculationRequest(), Helper.Options);
        
        httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        ProblemDetails? result = await httpResponseMessage.Content.ReadFromJsonAsync<ProblemDetails>(Helper.Options);
        result!.Detail.Should().Be(CalculationConstants.InvalidBaseCarPrice);
    }
}