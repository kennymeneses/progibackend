using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using DateOnlyTimeOnly.AspNet.Converters;
using FluentAssertions;

namespace BidCalculation.TestHelper;

public static class TestHelper
{
    public static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
        Converters =
        {
            new JsonStringEnumConverter(), new DateOnlyJsonConverter(), new TimeOnlyJsonConverter()
        }
    };
    
    public static async Task<EitherType> Read<EitherType>(this HttpResponseMessage response)
    {
        return await response.Content.ReadFromJsonAsync<EitherType>(Options) ?? throw new InvalidOperationException();
    }

    public static async Task<TResponse> Create<TRequest, TResponse>(this HttpClient client, string uri,
        TRequest request, HttpStatusCode statusCode = HttpStatusCode.Created)
    {
        HttpResponseMessage httpResponseMessage = await client.PostAsJsonAsync(uri, request, Options);
        httpResponseMessage.StatusCode.Should().Be(statusCode);
        TResponse response = await httpResponseMessage.Read<TResponse>();
        return response;
    }
}