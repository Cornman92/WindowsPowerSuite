namespace WindowsPowerSuite.Core.Interfaces;

/// <summary>
/// Base interface for all pluggable modules in WindowsPowerSuite.
/// </summary>
public interface IModuleBase
{
    /// <summary>
    /// Gets the name of the module.
    /// </summary>
    string ModuleName { get; }

    /// <summary>
    /// Gets the description of the module.
    /// </summary>
    string ModuleDescription { get; }

    /// <summary>
    /// Gets the icon identifier for the module.
    /// </summary>
    string ModuleIcon { get; }

    /// <summary>
    /// Gets the version of the module.
    /// </summary>
    Version ModuleVersion { get; }

    /// <summary>
    /// Gets the category of the module.
    /// </summary>
    string Category { get; }

    /// <summary>
    /// Gets a value indicating whether this module requires administrator elevation.
    /// </summary>
    bool RequiresElevation { get; }

    /// <summary>
    /// Initializes the module asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task InitializeAsync();

    /// <summary>
    /// Determines whether the module can execute in the current context.
    /// </summary>
    /// <returns>A task containing true if the module can execute; otherwise, false.</returns>
    Task<bool> CanExecuteAsync();

    /// <summary>
    /// Cleans up resources used by the module.
    /// </summary>
    void Cleanup();
}
