using BidCalculation.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCalculationHandler();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerVersioning();
builder.Services.AddCorsPolicy();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.AddSwaggerUiConfiguration();
}

app.UseHttpsRedirection();

app.UseCors(ConfigurationConstants.CorsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
