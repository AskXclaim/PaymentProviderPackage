using Application.Interfaces;
using Infrastructure.Services;

namespace WebApi.StartUp;

public static class DependenciesConfig
{
    public static void AddDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApiServices();
        builder.Services.AddEndpointServices();

        builder.Services.AddScoped<IPaymentGateway, CheckoutComPaymentGateway>();
        builder.Services.AddExceptionServices();
    }
}