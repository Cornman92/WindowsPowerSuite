# Source Code Structure

This directory contains all source code for WindowsPowerSuite.

## Project Structure

```
src/
├── WindowsPowerSuite.Core/          # Core library with shared interfaces and services
│   ├── Interfaces/                  # Service and module interfaces
│   ├── Models/                      # Shared data models
│   ├── Services/                    # Core service implementations
│   ├── Helpers/                     # Utility helpers
│   └── Extensions/                  # Extension methods
│
├── WindowsPowerSuite.App/           # Main WPF application
│   ├── Views/                       # XAML views
│   ├── ViewModels/                  # View models (MVVM pattern)
│   ├── Resources/                   # Application resources (styles, templates)
│   └── Converters/                  # Value converters
│
└── Modules/                         # Feature modules
    ├── WindowsPowerSuite.SystemInfo/
    ├── WindowsPowerSuite.ProcessManager/
    ├── WindowsPowerSuite.StartupManager/
    ├── WindowsPowerSuite.DiskAnalyzer/
    ├── WindowsPowerSuite.ServiceManager/
    ├── WindowsPowerSuite.NetworkTools/
    ├── WindowsPowerSuite.FileShredder/
    ├── WindowsPowerSuite.RegistryCleaner/
    ├── WindowsPowerSuite.BatchRenamer/
    └── WindowsPowerSuite.Scheduler/
```

## Building

To build the solution:

```bash
dotnet restore
dotnet build
```

To build in Release mode:

```bash
dotnet build --configuration Release
```

## Running

To run the application from source:

```bash
dotnet run --project WindowsPowerSuite.App
```

## Testing

Run all tests:

```bash
dotnet test
```

Run tests with coverage:

```bash
dotnet test /p:CollectCoverage=true
```

## Dependencies

### Core Library
- .NET 8.0
- Microsoft.Extensions.DependencyInjection
- Microsoft.Extensions.Hosting
- Serilog (Logging)
- System.Management (WMI)
- Newtonsoft.Json (Configuration)

### Application
- .NET 8.0 Windows
- WPF
- ModernWPF (Fluent Design UI)
- CommunityToolkit.Mvvm (MVVM helpers)
- LiveChartsCore (Charts and visualizations)

### Modules
All modules depend on:
- WindowsPowerSuite.Core
- CommunityToolkit.Mvvm

Some modules have additional dependencies:
- ProcessManager: LiveChartsCore (for graphs)
- StartupManager: Microsoft.Win32.TaskScheduler
- ServiceManager: System.ServiceProcess.ServiceController
- Scheduler: Microsoft.Win32.TaskScheduler

## Development Guidelines

1. **MVVM Pattern**: All UI follows Model-View-ViewModel pattern
2. **Dependency Injection**: Use constructor injection for all dependencies
3. **Async/Await**: Use async patterns for all I/O operations
4. **Error Handling**: Return OperationResult<T> for operations that can fail
5. **XML Comments**: Document all public APIs
6. **Testing**: Maintain 80%+ code coverage

## Module Development

Each module should:
1. Implement `IModuleBase` interface
2. Use MVVM pattern for UI
3. Register services in DI container
4. Include unit tests
5. Follow the established folder structure:
   - Models/
   - Services/
   - ViewModels/
   - Views/

## Code Style

- Use C# 12 features
- Enable nullable reference types
- Follow .editorconfig settings
- Use `var` for local variables
- PascalCase for classes, methods, properties
- camelCase for parameters, local variables
- _camelCase for private fields

## More Information

See the root-level documentation:
- [PLAN.md](../PLAN.md) - Comprehensive development plan
- [TASKS.md](../TASKS.md) - Detailed task breakdown
- [DEVELOPMENT_WORKFLOW.md](../DEVELOPMENT_WORKFLOW.md) - Development processes
