namespace WebApi.StartUp;

public static class EndPointConfig
{
    public static void AddEndpointServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
    }
}