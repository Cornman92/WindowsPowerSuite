# WindowsPowerSuite - Development Workflow

> Last Updated: December 18, 2025

This document outlines the development processes, conventions, and best practices for the WindowsPowerSuite project.

---

## Table of Contents
1. [Development Environment Setup](#development-environment-setup)
2. [Git Workflow](#git-workflow)
3. [Coding Standards](#coding-standards)
4. [Testing Workflow](#testing-workflow)
5. [Code Review Process](#code-review-process)
6. [CI/CD Pipeline](#cicd-pipeline)
7. [Release Process](#release-process)
8. [Documentation Workflow](#documentation-workflow)

---

## Development Environment Setup

### Prerequisites

#### Required Software
- **IDE:** Visual Studio 2022 (17.8+) or JetBrains Rider (2023.3+)
- **.NET SDK:** .NET 8.0 SDK
- **Windows SDK:** Windows 10/11 SDK
- **Git:** Latest version
- **WiX Toolset:** v4.x (for installer development)

#### Optional Tools
- **GitHub Desktop:** For Git GUI
- **Windows Terminal:** Enhanced terminal experience
- **dotnet-format:** Code formatting tool
- **ReSharper:** Code analysis (if using Visual Studio)

### Initial Setup

```bash
# Clone the repository
git clone https://github.com/yourusername/WindowsPowerSuite.git
cd WindowsPowerSuite

# Check .NET version
dotnet --version  # Should be 8.0.x or higher

# Restore NuGet packages
dotnet restore

# Build the solution
dotnet build

# Run tests
dotnet test
```

### IDE Configuration

#### Visual Studio 2022
1. Install required workloads:
   - .NET desktop development
   - Windows application development
2. Install extensions:
   - CodeMaid (optional)
   - Markdown Editor (optional)
3. Configure Code Style:
   - Tools > Options > Text Editor > C# > Code Style
   - Import `.editorconfig` (will be created)

#### Rider
1. Configure .NET SDK path
2. Enable EditorConfig support
3. Install plugins:
   - Markdown (usually built-in)

---

## Git Workflow

### Branch Strategy

We use **Git Flow** branching strategy:

```
main (production releases)
  │
  └─► develop (integration branch)
        │
        ├─► feature/feature-name (new features)
        ├─► bugfix/bug-description (bug fixes)
        ├─► hotfix/critical-fix (urgent production fixes)
        └─► release/v1.0.0 (release preparation)
```

### Branch Naming Conventions

- **Feature branches:** `feature/short-description`
  - Example: `feature/process-manager-ui`
- **Bug fix branches:** `bugfix/issue-number-description`
  - Example: `bugfix/42-fix-memory-leak`
- **Hotfix branches:** `hotfix/critical-issue`
  - Example: `hotfix/startup-crash`
- **Release branches:** `release/v1.0.0`
  - Example: `release/v1.0.0`

### Workflow Steps

#### Starting a New Feature

```bash
# Ensure you're on develop branch
git checkout develop
git pull origin develop

# Create feature branch
git checkout -b feature/my-new-feature

# Work on your feature
# ... make changes ...

# Commit changes
git add .
git commit -m "feat: add my new feature"

# Push to remote
git push origin feature/my-new-feature

# Create pull request on GitHub
```

#### Fixing a Bug

```bash
# Create bugfix branch from develop
git checkout develop
git pull origin develop
git checkout -b bugfix/42-fix-startup-crash

# Fix the bug
# ... make changes ...

# Commit the fix
git commit -m "fix: resolve startup crash (closes #42)"

# Push and create PR
git push origin bugfix/42-fix-startup-crash
```

#### Hotfix (Critical Production Bug)

```bash
# Create hotfix from main
git checkout main
git pull origin main
git checkout -b hotfix/critical-security-fix

# Fix the issue
# ... make changes ...

# Commit
git commit -m "hotfix: fix critical security vulnerability"

# Push
git push origin hotfix/critical-security-fix

# Create PR to main AND develop
```

### Commit Message Format

We follow **Conventional Commits** specification:

```
<type>(<scope>): <subject>

<body>

<footer>
```

#### Types
- **feat:** New feature
- **fix:** Bug fix
- **docs:** Documentation changes
- **style:** Code style changes (formatting, semicolons, etc.)
- **refactor:** Code refactoring
- **perf:** Performance improvements
- **test:** Adding or updating tests
- **chore:** Maintenance tasks, dependency updates
- **ci:** CI/CD changes
- **build:** Build system changes

#### Examples

```bash
# Simple feature
git commit -m "feat: add CPU temperature monitoring"

# Bug fix with issue reference
git commit -m "fix: resolve memory leak in process monitor (fixes #42)"

# Feature with scope
git commit -m "feat(disk-analyzer): add duplicate file detection"

# Breaking change
git commit -m "feat!: change settings file format

BREAKING CHANGE: Settings format changed from XML to JSON.
Users need to reconfigure their settings after update."

# With detailed body
git commit -m "refactor: improve performance of disk scanning

- Implement parallel directory traversal
- Add caching for frequently accessed paths
- Reduce memory allocations

Performance improved by 3x on large directories."
```

### Pull Request Process

1. **Create PR** from feature/bugfix branch to `develop`
2. **Fill PR template** with description, testing info
3. **Link related issues** using "Fixes #123"
4. **Ensure CI passes** (build, tests, linting)
5. **Request reviews** (if team exists)
6. **Address feedback** through additional commits
7. **Squash and merge** once approved

### PR Title Format
Use same format as commit messages:
- `feat: add disk analyzer module`
- `fix: resolve startup crash`
- `docs: update installation guide`

---

## Coding Standards

### C# Coding Conventions

#### Naming Conventions

```csharp
// Classes: PascalCase
public class ProcessManager { }

// Interfaces: IPascalCase
public interface IProcessService { }

// Methods: PascalCase
public void GetProcessList() { }

// Properties: PascalCase
public string ProcessName { get; set; }

// Fields (private): _camelCase
private readonly ILogger _logger;

// Constants: PascalCase
public const int MaxProcessCount = 1000;

// Parameters: camelCase
public void StartProcess(string processName, int timeout) { }

// Local variables: camelCase
var processCount = GetProcessCount();
```

#### Code Organization

```csharp
public class MyClass
{
    // 1. Constants
    private const int DefaultTimeout = 30;

    // 2. Fields
    private readonly ILogger _logger;
    private readonly IProcessService _processService;

    // 3. Constructor
    public MyClass(ILogger logger, IProcessService processService)
    {
        _logger = logger;
        _processService = processService;
    }

    // 4. Properties
    public string Name { get; set; }
    public int ProcessCount { get; private set; }

    // 5. Public methods
    public async Task<List<Process>> GetProcessesAsync()
    {
        // Implementation
    }

    // 6. Private methods
    private void LogError(string message)
    {
        _logger.LogError(message);
    }
}
```

#### Async/Await Guidelines

```csharp
// ✅ Good: Async method naming
public async Task<ProcessInfo> GetProcessInfoAsync(int processId)
{
    // Use ConfigureAwait(false) in library code
    var process = await _repository.GetProcessAsync(processId)
        .ConfigureAwait(false);
    return process;
}

// ❌ Bad: Blocking on async code
public ProcessInfo GetProcessInfo(int processId)
{
    return GetProcessInfoAsync(processId).Result; // Don't do this!
}

// ✅ Good: Proper cancellation support
public async Task ScanDirectoryAsync(string path, CancellationToken cancellationToken)
{
    foreach (var file in files)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await ProcessFileAsync(file, cancellationToken);
    }
}
```

#### Error Handling

```csharp
// ✅ Good: Specific exception handling
public async Task<OperationResult<ProcessInfo>> GetProcessInfoAsync(int processId)
{
    try
    {
        var process = await _processService.GetProcessAsync(processId);
        return OperationResult<ProcessInfo>.SuccessResult(process);
    }
    catch (ProcessNotFoundException ex)
    {
        _logger.LogWarning(ex, "Process {ProcessId} not found", processId);
        return OperationResult<ProcessInfo>.ErrorResult("Process not found", ex);
    }
    catch (UnauthorizedAccessException ex)
    {
        _logger.LogError(ex, "Access denied to process {ProcessId}", processId);
        return OperationResult<ProcessInfo>.ErrorResult("Access denied", ex);
    }
}

// ❌ Bad: Catching all exceptions
try { }
catch (Exception) { } // Too broad
```

#### LINQ Usage

```csharp
// ✅ Good: Clear LINQ queries
var runningProcesses = processes
    .Where(p => p.Status == ProcessStatus.Running)
    .OrderBy(p => p.Name)
    .Select(p => new ProcessViewModel(p))
    .ToList();

// ✅ Good: Method syntax for complex queries
var result = await processes
    .Where(p => p.CpuUsage > 50)
    .GroupBy(p => p.Name)
    .Select(g => new { Name = g.Key, Count = g.Count() })
    .ToListAsync();
```

### XAML Conventions

```xml
<!-- Element naming: x:Name in PascalCase -->
<Button x:Name="StartButton" Content="Start" />

<!-- Event handlers: Element_Event format -->
<Button Click="StartButton_Click" />

<!-- Resources: PascalCase keys -->
<SolidColorBrush x:Key="PrimaryBrush" Color="#007ACC" />

<!-- Formatting: Each attribute on new line for complex elements -->
<Button
    x:Name="ComplexButton"
    Content="Click Me"
    Command="{Binding StartCommand}"
    CommandParameter="{Binding SelectedItem}"
    Style="{StaticResource PrimaryButtonStyle}" />
```

### Code Comments

```csharp
// ✅ Good: XML documentation for public APIs
/// <summary>
/// Retrieves process information for the specified process ID.
/// </summary>
/// <param name="processId">The ID of the process to retrieve.</param>
/// <param name="cancellationToken">Cancellation token.</param>
/// <returns>Operation result containing process information.</returns>
/// <exception cref="ArgumentException">Thrown when processId is invalid.</exception>
public async Task<OperationResult<ProcessInfo>> GetProcessInfoAsync(
    int processId,
    CancellationToken cancellationToken = default)
{
    // Inline comments for complex logic
    // TODO: Add caching to improve performance
    var process = await _repository.GetAsync(processId, cancellationToken);
    return OperationResult<ProcessInfo>.SuccessResult(process);
}
```

---

## Testing Workflow

### Test Structure

```
tests/
├── WindowsPowerSuite.Core.Tests/
│   ├── Services/
│   │   ├── ProcessServiceTests.cs
│   │   └── RegistryServiceTests.cs
│   ├── Models/
│   └── Helpers/
└── WindowsPowerSuite.SystemInfo.Tests/
    ├── ViewModels/
    └── Services/
```

### Unit Test Conventions

```csharp
public class ProcessServiceTests
{
    // Naming: MethodName_Scenario_ExpectedResult
    [Fact]
    public async Task GetProcessAsync_ValidProcessId_ReturnsProcess()
    {
        // Arrange
        var mockRepository = new Mock<IProcessRepository>();
        mockRepository
            .Setup(r => r.GetAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Process { Id = 1, Name = "test" });

        var service = new ProcessService(mockRepository.Object);

        // Act
        var result = await service.GetProcessAsync(1);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(1);
        result.Name.Should().Be("test");
    }

    [Fact]
    public async Task GetProcessAsync_InvalidProcessId_ThrowsException()
    {
        // Arrange
        var service = new ProcessService(Mock.Of<IProcessRepository>());

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(
            () => service.GetProcessAsync(-1));
    }
}
```

### Running Tests

```bash
# Run all tests
dotnet test

# Run tests with coverage
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover

# Run specific test
dotnet test --filter "FullyQualifiedName=WindowsPowerSuite.Core.Tests.ProcessServiceTests.GetProcessAsync_ValidProcessId_ReturnsProcess"

# Run tests in specific project
dotnet test tests/WindowsPowerSuite.Core.Tests
```

### Test Coverage Goals
- **Target:** 80% code coverage
- **Minimum:** 70% for new features
- **Core library:** 90%+ coverage

---

## Code Review Process

### Review Checklist

#### Functionality
- [ ] Code works as intended
- [ ] Edge cases handled
- [ ] Error handling implemented
- [ ] No obvious bugs

#### Code Quality
- [ ] Follows coding standards
- [ ] No code duplication
- [ ] Clear and maintainable
- [ ] Appropriate abstraction level

#### Testing
- [ ] Unit tests included
- [ ] Tests pass
- [ ] Adequate coverage
- [ ] Tests are meaningful

#### Documentation
- [ ] XML comments for public APIs
- [ ] Complex logic explained
- [ ] README updated if needed
- [ ] CHANGELOG updated

#### Performance
- [ ] No obvious performance issues
- [ ] Efficient algorithms used
- [ ] Resources properly disposed
- [ ] No memory leaks

#### Security
- [ ] No security vulnerabilities
- [ ] Input validation present
- [ ] Sensitive data handled properly
- [ ] UAC elevation when needed

### Review Process

1. **Self-review first:** Review your own code before submitting PR
2. **Automated checks:** Ensure CI passes before requesting review
3. **Request review:** Tag appropriate reviewers
4. **Address feedback:** Respond to all comments
5. **Re-request review:** After addressing feedback
6. **Approval:** At least one approval required
7. **Merge:** Squash and merge to develop

---

## CI/CD Pipeline

### GitHub Actions Workflow

```yaml
# .github/workflows/build.yml
name: Build and Test

on:
  push:
    branches: [ develop, main ]
  pull_request:
    branches: [ develop, main ]

jobs:
  build:
    runs-on: windows-latest

    steps:
    - uses: actions/checkout@v3

    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: 8.0.x

    - name: Restore dependencies
      run: dotnet restore

    - name: Build
      run: dotnet build --no-restore --configuration Release

    - name: Test
      run: dotnet test --no-build --configuration Release --collect:"XPlat Code Coverage"

    - name: Upload coverage
      uses: codecov/codecov-action@v3
```

### Build Status Badges

Add to README.md:
```markdown
![Build Status](https://github.com/username/WindowsPowerSuite/workflows/Build%20and%20Test/badge.svg)
![Code Coverage](https://codecov.io/gh/username/WindowsPowerSuite/branch/develop/graph/badge.svg)
```

---

## Release Process

### Version Numbering

We follow **Semantic Versioning** (SemVer):
- **MAJOR.MINOR.PATCH** (e.g., 1.2.3)
- **MAJOR:** Breaking changes
- **MINOR:** New features, backward compatible
- **PATCH:** Bug fixes, backward compatible

### Release Steps

#### 1. Prepare Release Branch

```bash
# Create release branch from develop
git checkout develop
git pull origin develop
git checkout -b release/v1.0.0

# Update version numbers
# - AssemblyInfo.cs
# - WiX installer version
# - CHANGELOG.md

git commit -m "chore: bump version to 1.0.0"
git push origin release/v1.0.0
```

#### 2. Testing & Bug Fixes

- Perform thorough testing
- Fix any discovered bugs on release branch
- No new features on release branch

#### 3. Finalize Release

```bash
# Merge to main
git checkout main
git merge --no-ff release/v1.0.0
git tag -a v1.0.0 -m "Release version 1.0.0"
git push origin main --tags

# Merge back to develop
git checkout develop
git merge --no-ff release/v1.0.0
git push origin develop

# Delete release branch
git branch -d release/v1.0.0
git push origin --delete release/v1.0.0
```

#### 4. Create GitHub Release

1. Go to GitHub Releases
2. Click "Create a new release"
3. Select tag v1.0.0
4. Title: "WindowsPowerSuite v1.0.0"
5. Add release notes (from CHANGELOG.md)
6. Upload installer and portable zip
7. Publish release

### CHANGELOG Format

```markdown
# Changelog

## [1.0.0] - 2026-01-15

### Added
- Initial release
- System Information module
- Process Manager module
- ... (all 10 modules)

### Changed
- N/A (first release)

### Fixed
- N/A (first release)

### Security
- N/A (first release)
```

---

## Documentation Workflow

### Documentation Types

1. **Code Documentation** - XML comments in code
2. **User Documentation** - User guides, tutorials
3. **Developer Documentation** - Architecture, API docs
4. **Planning Documentation** - This file, PLAN.md, etc.

### Documentation Updates

#### When to Update Documentation

- **Code changes:** Update XML comments
- **New features:** Update user guide
- **API changes:** Update API documentation
- **Architecture changes:** Update ARCHITECTURE.md
- **Process changes:** Update this file

#### Documentation Review

- Documentation reviewed as part of PR
- Must be clear and accurate
- Examples where appropriate
- Screenshots for UI features

---

## Best Practices Summary

### DO ✅

- Write clean, readable code
- Follow naming conventions
- Write meaningful commit messages
- Write unit tests
- Document public APIs
- Handle errors gracefully
- Use async/await properly
- Dispose resources properly
- Review your own code first
- Keep PRs focused and small
- Update documentation

### DON'T ❌

- Commit directly to main/develop
- Push broken code
- Skip tests
- Ignore compiler warnings
- Use `// TODO` without issue number
- Catch generic exceptions
- Block on async code
- Leave commented-out code
- Commit sensitive data
- Make huge PRs

---

## Troubleshooting

### Common Issues

#### Build Failures
```bash
# Clean and rebuild
dotnet clean
dotnet restore
dotnet build
```

#### Test Failures
```bash
# Run tests with verbose output
dotnet test --logger "console;verbosity=detailed"
```

#### Git Issues
```bash
# Reset to remote state
git fetch origin
git reset --hard origin/develop
```

---

## Resources

### Learning Resources
- [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [WPF Documentation](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
- [ModernWPF UI](https://github.com/Kinnara/ModernWpf)
- [xUnit Documentation](https://xunit.net/)

### Tools
- [Visual Studio](https://visualstudio.microsoft.com/)
- [.NET SDK](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)
- [WiX Toolset](https://wixtoolset.org/)

---

*This workflow document is a living document. If you find areas for improvement, please submit a PR!*
