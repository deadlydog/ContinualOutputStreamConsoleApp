# Continual Output Stream Console App

A basic console application that will continually write to the Standard Output stream and/or the Standard Error stream.

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

## Examples

```Cmd
ContinualOutput.exe /number 5
```

Display a message from the Standard Output stream 5 times.

---

```Cmd
ContinualOutput.exe /time 5000
```

Display messages from the Standard Output stream for 5 seconds (5000 milliseconds).

---

```Cmd
ContinualOutput.exe /number 100 /delay 10
```

Display a message from the Standard Output stream 100 times, with a 10 millisecond delay between each message (default delay is 1 second).

---

```Cmd
ContinualOutput.exe /number 5 /outputType All
```

Display a message from both the Standard Output and Standard Error streams 5 times.

---

```Cmd
ContinualOutput.exe /number 5 /throwException /exceptionMessage "Oh no, something bad happened"
```

Display a message from the Standard Output stream 5 times, and then throw an exception with a custom message before exiting.