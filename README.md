# Weather API Console App

> **Note**: This project was developed with the assistance of AI as part of the **AI Training for Software Developer** course by **Generation Brazil**. Learn more at [https://brazil.generation.org](https://brazil.generation.org)

## Project Overview

This is a C# console application built with .NET 10 that fetches current weather information for any city. It uses free APIs from Open-Meteo to get accurate weather data without needing an API key. The application follows SOLID principles with proper separation of concerns, dependency injection, and comprehensive unit testing.

## Architecture

The project is structured following SOLID principles:

- **Single Responsibility Principle (SRP)**: Each class has a single, well-defined purpose. Tests are organized into specialized classes (`WeatherServiceValidationTests`, `WeatherServiceApiFailureTests`, `WeatherServiceSuccessTests`, `IWeatherServiceContractTests`)
- **Open/Closed Principle (OCP)**: Classes are open for extension but closed for modification via helpers and abstractions
- **Liskov Substitution Principle (LSP)**: Interface-based design allows for easy substitution of implementations
- **Interface Segregation Principle (ISP)**: Clean interfaces (`IWeatherService`) with minimal dependencies
- **Dependency Inversion Principle (DIP)**: High-level modules depend on abstractions (`IWeatherService`) not concrete implementations

### Key Components

| File | Description |
|------|-------------|
| `IWeatherService.cs` | Interface defining weather service contract |
| `WeatherService.cs` | Implementation handling API calls and data processing |
| `WeatherData.cs` | Model representing weather information |
| `GeoModels.cs` | Models for geocoding API responses |
| `WeatherModels.cs` | Models for weather API responses |

## Installation Instructions

1. **Install .NET SDK**: Ensure you have .NET 10 SDK installed
2. **Clone or Download the Project**: Get the project files
3. **Open in Visual Studio Code**: Launch VS Code and open the project folder
4. **Restore Dependencies**: Run `dotnet restore` in the terminal

## Usage Guide

1. **Build the Project**: Run `dotnet build ia-project.csproj`
2. **Run the App**: Execute `dotnet run --project ia-project.csproj`
3. **Enter a City Name**: Type a city name when prompted
4. **View Results**: See current weather information

## Example Output

```
Enter city name: London
Weather in London:
Temperature: 15.2°C
Wind Speed: 12.5 km/h
Weather Code: 3
```

## Features

- **City Input Validation**: Handles empty, null, and special character inputs
- **Geocoding Integration**: Converts city names to coordinates using Open-Meteo Geocoding API
- **Real-time Weather Data**: Fetches current temperature, wind speed, and weather codes
- **Comprehensive Error Handling**: Graceful handling of API failures and invalid inputs
- **SOLID Architecture**: Clean, maintainable, and extensible code structure

## Testing

The project includes comprehensive unit tests organized following SOLID principles:

### Test Structure

```
WeatherApp.Tests/
├── WeatherServiceValidationTests.cs    # Input validation tests (SRP)
├── WeatherServiceApiFailureTests.cs    # API failure scenario tests
├── WeatherServiceSuccessTests.cs       # Success scenario tests
├── IWeatherServiceContractTests.cs     # Interface contract tests (DIP)
├── TestHelpers.cs                     # Shared test utilities (DRY)
├── FakeHttpMessageHandler.cs           # HTTP mock handler
└── WeatherApp.Tests.csproj            # Test project configuration
```

### Test Coverage

| Test Class | Description | Tests |
|------------|-------------|-------|
| `WeatherServiceValidationTests` | Input validation for null/empty/whitespace city names | 1 (parameterized) |
| `WeatherServiceApiFailureTests` | API failure scenarios (city not found, HTTP errors, missing data) | 4 |
| `WeatherServiceSuccessTests` | Successful weather retrieval and special characters | 3 |
| `IWeatherServiceContractTests` | Interface contract verification using Moq | 4 |

### Running Tests

```bash
cd WeatherApp.Tests
dotnet test
```

**Status**: All 14 tests passing.

### Testing Technologies

- **xUnit**: Test framework
- **Moq**: Mocking library for interface-based testing (DIP)
- **FakeHttpMessageHandler**: Custom mock for HttpClient testing

## API Information

Uses two free Open-Meteo APIs:
- **Geocoding API** (https://geocoding-api.open-meteo.com/v1/search): Converts city names to coordinates
- **Weather API** (https://api.open-meteo.com/v1/forecast): Provides current weather data

No API keys required - completely free to use.

## Error Handling

The app provides user-friendly error messages for:
- Invalid or empty city names (throws `ArgumentException`)
- Cities not found in the geocoding service (throws `InvalidOperationException`)
- Network connectivity issues (throws `HttpRequestException`)
- API response parsing errors (throws `InvalidOperationException`)

## Project Structure

```
ia-project/
├── Program.cs                          # Main application entry point
├── IWeatherService.cs                  # Weather service interface (abstraction)
├── WeatherService.cs                   # Weather service implementation
├── WeatherData.cs                      # Weather data model
├── GeoModels.cs                        # Geocoding response models
├── WeatherModels.cs                    # Weather response models
├── ia-project.csproj                  # Main project file
├── Directory.Build.props               # Build configuration
├── ia-project.sln                      # Solution file
├── WeatherApp.Tests/                   # Unit test project (follows SOLID)
│   ├── WeatherServiceValidationTests.cs
│   ├── WeatherServiceApiFailureTests.cs
│   ├── WeatherServiceSuccessTests.cs
│   ├── IWeatherServiceContractTests.cs
│   ├── TestHelpers.cs
│   ├── FakeHttpMessageHandler.cs
│   └── WeatherApp.Tests.csproj
└── README.md                          # This documentation
```

## Dependencies

### Main Project
- .NET 10.0 SDK

### Test Project
- xUnit 2.9.2
- xUnit.runner.visualstudio 2.8.2
- Microsoft.NET.Test.Sdk 17.12.0
- Moq 4.20.72

## Future Improvements

- Add more weather details, like humidity or forecast for the next few days
- Create a graphical user interface (GUI) using Windows Forms or WPF
- Support multiple cities at once or save favorite locations
- Add integration tests with real API responses
- Improve error handling with retry options for network failures
