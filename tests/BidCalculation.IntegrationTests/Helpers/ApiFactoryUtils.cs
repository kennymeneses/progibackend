using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace BidCalculation.IntegrationTests.Helpers;

public static class ApiFactoryUtils
{
    public static void RemoveBackgroundServices(IServiceCollection services)
    {
        services.RemoveAll(typeof(IHostedService));
    }
}