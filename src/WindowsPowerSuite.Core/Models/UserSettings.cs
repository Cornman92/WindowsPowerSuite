namespace WindowsPowerSuite.Core.Models;

/// <summary>
/// Represents application-wide user settings.
/// </summary>
public class UserSettings
{
    /// <summary>
    /// Gets or sets the theme setting (System, Light, Dark).
    /// </summary>
    public string Theme { get; set; } = "System";

    /// <summary>
    /// Gets or sets the language/culture setting.
    /// </summary>
    public string Language { get; set; } = "en-US";

    /// <summary>
    /// Gets or sets a value indicating whether the application should start minimized.
    /// </summary>
    public bool StartMinimized { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether the application should minimize to the system tray.
    /// </summary>
    public bool MinimizeToTray { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether the application should check for updates automatically.
    /// </summary>
    public bool CheckForUpdates { get; set; } = true;

    /// <summary>
    /// Gets or sets the update channel (Stable, Beta).
    /// </summary>
    public string UpdateChannel { get; set; } = "Stable";

    /// <summary>
    /// Gets or sets the logging level.
    /// </summary>
    public string LoggingLevel { get; set; } = "Information";

    /// <summary>
    /// Gets or sets module-specific settings.
    /// </summary>
    public Dictionary<string, object> ModuleSettings { get; set; } = new();

    /// <summary>
    /// Gets or sets the last window width.
    /// </summary>
    public double WindowWidth { get; set; } = 1200;

    /// <summary>
    /// Gets or sets the last window height.
    /// </summary>
    public double WindowHeight { get; set; } = 800;

    /// <summary>
    /// Gets or sets a value indicating whether the window was maximized.
    /// </summary>
    public bool IsWindowMaximized { get; set; } = false;

    /// <summary>
    /// Gets or sets the selected module on startup.
    /// </summary>
    public string? LastSelectedModule { get; set; }
}
