using BidCalculation.Api;
using BidCalculation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BidCalculation.IntegrationTests.Helpers;
public class BidCalculationApiFactory : WebApplicationFactory<IApiMarker>
{
    public HttpClient HttpClient { get; private set; }

    public BidCalculationApiFactory()
    {
        HttpClient = CreateClient();
    }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(
            services =>
            {
                services.RemoveAll(typeof(IHostedService));
            });

        builder.ConfigureLogging(logging => logging.ClearProviders());

        builder.UseEnvironment(HelperConstants.TestEnvName);
    }
}