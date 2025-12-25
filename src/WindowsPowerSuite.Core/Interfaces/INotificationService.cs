namespace WindowsPowerSuite.Core.Interfaces;

/// <summary>
/// Provides toast notification and dialog functionality.
/// </summary>
public interface INotificationService
{
    /// <summary>
    /// Shows a success notification.
    /// </summary>
    /// <param name="title">The notification title.</param>
    /// <param name="message">The notification message.</param>
    void ShowSuccess(string title, string message);

    /// <summary>
    /// Shows an informational notification.
    /// </summary>
    /// <param name="title">The notification title.</param>
    /// <param name="message">The notification message.</param>
    void ShowInfo(string title, string message);

    /// <summary>
    /// Shows a warning notification.
    /// </summary>
    /// <param name="title">The notification title.</param>
    /// <param name="message">The notification message.</param>
    void ShowWarning(string title, string message);

    /// <summary>
    /// Shows an error notification.
    /// </summary>
    /// <param name="title">The notification title.</param>
    /// <param name="message">The notification message.</param>
    void ShowError(string title, string message);

    /// <summary>
    /// Shows a confirmation dialog and waits for user response.
    /// </summary>
    /// <param name="title">The dialog title.</param>
    /// <param name="message">The dialog message.</param>
    /// <param name="defaultYes">Whether Yes should be the default button.</param>
    /// <returns>A task containing true if the user confirmed; otherwise, false.</returns>
    Task<bool> ShowConfirmationAsync(string title, string message, bool defaultYes = false);

    /// <summary>
    /// Shows a prompt dialog for user input.
    /// </summary>
    /// <param name="title">The dialog title.</param>
    /// <param name="message">The dialog message.</param>
    /// <param name="defaultValue">The default input value.</param>
    /// <returns>A task containing the user input, or null if cancelled.</returns>
    Task<string?> ShowPromptAsync(string title, string message, string defaultValue = "");
}
