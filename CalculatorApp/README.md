# Calculator Application

This is a simple calculator application built in C#. It supports basic arithmetic operations such as addition, subtraction, multiplication, and division.

## Project Structure

```
CalculatorApp
├── CalculatorApp.sln
├── src
│   ├── CalculatorApp
│   │   ├── Program.cs
│   │   ├── Calculator.cs
│   │   └── CalculatorApp.csproj
├── tests
│   ├── CalculatorApp.Tests
│   │   ├── CalculatorTests.cs
│   │   └── CalculatorApp.Tests.csproj
└── README.md
```

## Getting Started

### Prerequisites

- .NET SDK (version 5.0 or later)

### Building the Application

1. Open a terminal and navigate to the `CalculatorApp` directory.
2. Run the following command to build the application:

   ```
   dotnet build src/CalculatorApp/CalculatorApp.csproj
   ```

### Running the Application

To run the application, use the following command:

```
dotnet run --project src/CalculatorApp/CalculatorApp.csproj
```

### Running Tests

To run the unit tests, navigate to the `tests/CalculatorApp.Tests` directory and execute:

```
dotnet test
```

## Usage

Once the application is running, you can perform basic arithmetic operations by following the prompts in the console. 

## Contributing

Feel free to fork the repository and submit pull requests for any improvements or features you would like to add.