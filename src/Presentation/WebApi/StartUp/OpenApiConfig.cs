using Microsoft.OpenApi;
using Scalar.AspNetCore;

namespace WebApi.StartUp;

public static class OpenApiConfig
{
    public static void AddOpenApiServices(this IServiceCollection services) =>
        services.AddOpenApi(options => { options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_0; });

    public static void UseOpenApi(this WebApplication app)
    {
        const string apiName = "Payment-Package-WebApi";
        if (!app.Environment.IsDevelopment()) return;
        app.MapOpenApi();
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.DocumentTitle = apiName;
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        });
        app.MapScalarApiReference(options =>
        {
            options.Title = apiName;
            options.Theme = ScalarTheme.Solarized;
            options.HideClientButton = true;
        });
    }
}