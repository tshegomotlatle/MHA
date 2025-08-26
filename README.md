![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
[![CI](https://github.com/tshegomotlatle/MHA/actions/workflows/ci.yml/badge.svg)](https://github.com/tshegomotlatle/MHA/actions/workflows/ci.yml)
[![CodeQL Advanced](https://github.com/tshegomotlatle/MHA/actions/workflows/codeql.yml/badge.svg)](https://github.com/tshegomotlatle/MHA/actions/workflows/codeql.yml)
# MHA Solution

## Overview

This solution contains a set of algorithmic implementations, each encapsulated in its own class and executed via the main program. The project targets **.NET 9** and includes comprehensive unit tests using **xUnit**.

## Projects

- **MHA**: Main executable containing all implementations and the entry point.
- **MHA.Tests**: Unit test project for validating the implementations.

## Implementations

The solution includes the following algorithmic modules:
- `HistorianHysteria`
- `RedNosedReport`
- `MullItOver`
- `CeresSearch`
- `PrintQueue`
- `GuardGallivant`
- `BridgeRepair`
- `ResonantCollinearity`

Each implementation provides a `Calculate()` method for its core logic.

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 (recommended)

### Build and Run

1. **Clone the repository** and open the solution in Visual Studio 2022.
2. **Restore NuGet packages** (should happen automatically).
3. **Build the solution** (`Ctrl+Shift+B`).
4. **Run the main project** (`MHA`) to execute all implementations.

### Running Tests

- Open the **Test Explorer** in Visual Studio.
- Run all tests in the `MHA.Tests` project.

## Usage

The main program (`MHA/Program.cs`) instantiates and runs all implementations, printing their results to the console.

## Dependencies

- xUnit (unit testing)
- coverlet.collector (code coverage)

## License

This project is provided for educational and demonstration purposes.

