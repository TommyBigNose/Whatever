using AvaloniaApplication1.Services;
using AvaloniaApplication1.ViewModels;
using AvaloniaApplication1.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaApplication1.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection services)
    {
        // collection.AddSingleton<IRepository, Repository>();
        // collection.AddTransient<BusinessService>();
        // collection.AddTransient<MainViewModel>();
        
        services.AddScoped<MainWindowViewModel>();
        services.AddScoped<MainWindow>();
        services.AddScoped<ITestService, TestService>();
        services.AddScoped<IProgressBar, ProgressBar>();
    }
}