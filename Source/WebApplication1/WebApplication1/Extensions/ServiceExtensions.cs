namespace WebApplication1.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddTestServices(this IServiceCollection services)
    {
        services.AddScoped<ITestingProvider, TestingProvider>();

        return services;
    }
}