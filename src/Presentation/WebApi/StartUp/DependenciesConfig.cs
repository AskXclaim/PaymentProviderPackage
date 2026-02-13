using Application.Interfaces;
using Asp.Versioning;
using Infrastructure.Services;

namespace WebApi.StartUp;

public static class DependenciesConfig
{
    public static void AddDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApiServices();
        builder.Services.AddEndpointServices();
        builder.Services.AddSwaggerGen();
        builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
        });
        builder.Services.AddScoped<IPaymentGateway>(pg =>
            new CheckoutComPaymentGateway(builder.Configuration.GetSection("secretKey").Value));
        builder.Services.AddExceptionServices();
    }
}