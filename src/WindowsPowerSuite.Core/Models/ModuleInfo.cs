namespace WindowsPowerSuite.Core.Models;

/// <summary>
/// Contains metadata information about a module.
/// </summary>
public class ModuleInfo
{
    /// <summary>
    /// Gets or sets the module name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the module description.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Gets or sets the module icon identifier.
    /// </summary>
    public required string Icon { get; set; }

    /// <summary>
    /// Gets or sets the module version.
    /// </summary>
    public required Version Version { get; set; }

    /// <summary>
    /// Gets or sets the module category.
    /// </summary>
    public required string Category { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the module requires administrator elevation.
    /// </summary>
    public bool RequiresElevation { get; set; }

    /// <summary>
    /// Gets or sets the module type.
    /// </summary>
    public required Type ModuleType { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the module is enabled.
    /// </summary>
    public bool IsEnabled { get; set; } = true;

    /// <summary>
    /// Gets or sets the display order for the module.
    /// </summary>
    public int DisplayOrder { get; set; }
}
