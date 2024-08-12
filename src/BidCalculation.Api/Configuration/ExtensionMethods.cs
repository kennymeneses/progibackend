using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using BidCalculation.Api.Configuration.Swagger;
using BidCalculation.Application.Handlers.V1;
using BidCalculation.Application.Handlers.V1.Interfaces;
using Constants = BidCalculation.Api.Configuration.ConfigurationConstants;

namespace BidCalculation.Api.Configuration;

public static class ExtensionMethods
{
    public static void AddCalculationHandler(this IServiceCollection services)
    {
        services.AddScoped<ICarCostCalculationHandler, CarCostCalculationHandler>();
    }
    
    public static void AddSwaggerVersioning(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.ConfigureOptions<ConfigureSwaggerOptions>();
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(Constants.DefaultApiVersion, Constants.MinorApiVersion);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = Constants.GroupNameFormat;
            options.SubstituteApiVersionInUrl = true;
        });
    }

    public static void AddSwaggerUiConfiguration(this WebApplication app)
    {
        var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint(string.Format(Constants.SwaggerJsonEndpoint, description.GroupName),
                    description.GroupName.ToUpperInvariant());
            }
        });
    }

    public static void AddCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(
            options =>
            {
                options.AddPolicy(name: Constants.CorsPolicyName,
                    policy =>
                    {
                        policy.AllowAnyOrigin();
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                    });
            }
        );
    }
}