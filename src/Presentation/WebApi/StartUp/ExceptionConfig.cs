using WebApi.ExceptionHandling;

namespace WebApi.StartUp;

public static class ExceptionConfig
{
    public static void AddExceptionServices(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
    }
    public static void UseException(this WebApplication app) => app.UseExceptionHandler(); 
}