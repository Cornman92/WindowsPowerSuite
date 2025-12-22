using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WindowsPowerSuite.Core.Interfaces;

namespace WindowsPowerSuite.App;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IHost? _host;

    /// <summary>
    /// Gets the current application service provider.
    /// </summary>
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Create and configure the host
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                ConfigureServices(services);
            })
            .Build();

        ServiceProvider = _host.Services;

        // Initialize logging
        var loggingService = ServiceProvider.GetRequiredService<ILoggingService>();
        loggingService.LogInformation("WindowsPowerSuite starting...");

        // Load settings
        var settingsService = ServiceProvider.GetRequiredService<ISettingsService>();
        await settingsService.LoadSettingsAsync();

        await _host.StartAsync();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        // Save settings
        var settingsService = ServiceProvider?.GetService<ISettingsService>();
        if (settingsService != null)
        {
            await settingsService.SaveSettingsAsync();
        }

        // Cleanup
        if (_host != null)
        {
            await _host.StopAsync();
            _host.Dispose();
        }

        base.OnExit(e);
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Register core services
        // TODO: Implement actual service registrations
        // services.AddSingleton<ILoggingService, LoggingService>();
        // services.AddSingleton<ISettingsService, SettingsService>();
        // services.AddSingleton<ISystemService, SystemService>();
        // services.AddSingleton<INotificationService, NotificationService>();

        // Register ViewModels
        // services.AddTransient<MainWindowViewModel>();

        // Register modules
        // services.AddTransient<IModuleBase, SystemInfoModule>();
        // ... other modules
    }
}
