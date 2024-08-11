using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using BidCalculation.Application.Models.V1.Enums;
using BidCalculation.Application.Models.V1.Requests;
using DateOnlyTimeOnly.AspNet.Converters;
using FluentAssertions;

namespace BidCalculation.TestHelper;

public static class TestHelper
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
        Converters =
        {
            new JsonStringEnumConverter(), new DateOnlyJsonConverter(), new TimeOnlyJsonConverter()
        }
    };
    
    private static async Task<TEither> Read<TEither>(this HttpResponseMessage response)
    {
        return await response.Content.ReadFromJsonAsync<TEither>(Options) ?? throw new InvalidOperationException();
    }

    public static async Task<TResponse> Create<TRequest, TResponse>(this HttpClient client, string uri,
        TRequest request, HttpStatusCode statusCode = HttpStatusCode.Created)
    {
        HttpResponseMessage httpResponseMessage = await client.PostAsJsonAsync(uri, request, Options);
        httpResponseMessage.StatusCode.Should().Be(statusCode);
        TResponse response = await httpResponseMessage.Read<TResponse>();
        return response;
    }

    public static CarCostCalculationRequest CommonCalculationRequest()
    {
        return new CarCostCalculationRequest
        {
            CarCost = HelperConstants.CommonVehiclePrice,
            Type = VehicleType.Common
        };
    }

    public static CarCostCalculationRequest LuxuryCalculationRequest()
    {
        return new CarCostCalculationRequest
        {
            CarCost = HelperConstants.LuxuryVehiclePrice,
            Type = VehicleType.Luxury
        };
    }
}