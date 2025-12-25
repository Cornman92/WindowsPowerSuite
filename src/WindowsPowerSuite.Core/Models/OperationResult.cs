namespace WindowsPowerSuite.Core.Models;

/// <summary>
/// Represents the result of an operation with success/failure status and optional data.
/// </summary>
/// <typeparam name="T">The type of data returned by the operation.</typeparam>
public class OperationResult<T>
{
    /// <summary>
    /// Gets or sets a value indicating whether the operation was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets the data returned by the operation.
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// Gets or sets the error message if the operation failed.
    /// </summary>
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// Gets or sets the exception if the operation failed with an exception.
    /// </summary>
    public Exception? Exception { get; set; }

    /// <summary>
    /// Creates a successful operation result with data.
    /// </summary>
    /// <param name="data">The operation data.</param>
    /// <returns>A successful operation result.</returns>
    public static OperationResult<T> SuccessResult(T data)
    {
        return new OperationResult<T>
        {
            Success = true,
            Data = data
        };
    }

    /// <summary>
    /// Creates a failed operation result with an error message.
    /// </summary>
    /// <param name="errorMessage">The error message.</param>
    /// <param name="exception">Optional exception.</param>
    /// <returns>A failed operation result.</returns>
    public static OperationResult<T> ErrorResult(string errorMessage, Exception? exception = null)
    {
        return new OperationResult<T>
        {
            Success = false,
            ErrorMessage = errorMessage,
            Exception = exception
        };
    }
}

/// <summary>
/// Represents the result of an operation without data.
/// </summary>
public class OperationResult : OperationResult<object>
{
    /// <summary>
    /// Creates a successful operation result.
    /// </summary>
    /// <returns>A successful operation result.</returns>
    public static OperationResult Success()
    {
        return new OperationResult
        {
            Success = true
        };
    }

    /// <summary>
    /// Creates a failed operation result with an error message.
    /// </summary>
    /// <param name="errorMessage">The error message.</param>
    /// <param name="exception">Optional exception.</param>
    /// <returns>A failed operation result.</returns>
    public new static OperationResult ErrorResult(string errorMessage, Exception? exception = null)
    {
        return new OperationResult
        {
            Success = false,
            ErrorMessage = errorMessage,
            Exception = exception
        };
    }
}
