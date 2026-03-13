using Application.Interfaces;
using Infrastructure.Services;

namespace WebApi.StartUp;

public static class DependenciesConfig
{
    public static void AddDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApiServices();
        builder.Services.AddEndpointServices();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IPaymentGateway>(_ =>
            new CheckoutComPaymentGateway(builder.Configuration.GetSection("secretKey").Value));
        builder.Services.AddExceptionServices();
    }
}