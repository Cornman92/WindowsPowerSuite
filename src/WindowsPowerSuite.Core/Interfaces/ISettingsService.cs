namespace WindowsPowerSuite.Core.Interfaces;

/// <summary>
/// Provides application settings management with persistence and hot-reload support.
/// </summary>
public interface ISettingsService
{
    /// <summary>
    /// Gets a setting value.
    /// </summary>
    /// <typeparam name="T">The type of the setting value.</typeparam>
    /// <param name="key">The setting key.</param>
    /// <param name="defaultValue">The default value if the setting doesn't exist.</param>
    /// <returns>The setting value or the default value.</returns>
    T GetSetting<T>(string key, T defaultValue = default!);

    /// <summary>
    /// Sets a setting value.
    /// </summary>
    /// <typeparam name="T">The type of the setting value.</typeparam>
    /// <param name="key">The setting key.</param>
    /// <param name="value">The value to set.</param>
    void SetSetting<T>(string key, T value);

    /// <summary>
    /// Saves all settings to persistent storage.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SaveSettingsAsync();

    /// <summary>
    /// Loads settings from persistent storage.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task LoadSettingsAsync();

    /// <summary>
    /// Resets all settings to their default values.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task ResetSettingsAsync();

    /// <summary>
    /// Occurs when a setting value changes.
    /// </summary>
    event EventHandler<SettingChangedEventArgs>? SettingChanged;
}

/// <summary>
/// Provides data for the SettingChanged event.
/// </summary>
public class SettingChangedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the key of the setting that changed.
    /// </summary>
    public required string Key { get; init; }

    /// <summary>
    /// Gets the old value of the setting.
    /// </summary>
    public object? OldValue { get; init; }

    /// <summary>
    /// Gets the new value of the setting.
    /// </summary>
    public object? NewValue { get; init; }
}
