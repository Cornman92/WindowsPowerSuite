namespace WindowsPowerSuite.Core.Interfaces;

/// <summary>
/// Provides system-level operations and elevation capabilities.
/// </summary>
public interface ISystemService
{
    /// <summary>
    /// Gets a value indicating whether the current process is running with administrator privileges.
    /// </summary>
    bool IsAdministrator { get; }

    /// <summary>
    /// Gets the current Windows version information.
    /// </summary>
    string WindowsVersion { get; }

    /// <summary>
    /// Requests UAC elevation for the current process.
    /// </summary>
    /// <returns>A task containing true if elevation was successful; otherwise, false.</returns>
    Task<bool> RequestElevationAsync();

    /// <summary>
    /// Executes an operation with administrator privileges.
    /// </summary>
    /// <typeparam name="T">The return type of the operation.</typeparam>
    /// <param name="operation">The operation to execute.</param>
    /// <returns>A task containing the operation result.</returns>
    Task<Models.OperationResult<T>> ExecuteElevatedAsync<T>(Func<Task<T>> operation);

    /// <summary>
    /// Restarts the application with administrator privileges.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task RestartAsAdministratorAsync();
}
