# Continual Output Stream Console App

A basic console application that will continually write to the Standard Output stream, and optionally the Standard Error stream.

The main purpose of this is for testing tools that need to interact with console applications.

The solution contains both a .Net Framework project for creating a .exe console app, and a .Net Core project for creating a .dll console app.

## Usage

Run the console app without any arguments to see the command-line parameters.

e.g. Using the .Net Framework exe:

```Cmd
ContinualOutput.exe
```

e.g. Using the .Net Core dll:

```Cmd
dotnet ContinualOutput.dll
```