# Continual Output Stream Console App

A basic console application that will continually write to the Standard Output stream and/or the Standard Error stream.

The main purpose of this console app is for it to be used by other applications that need to test how they interact with console applications. e.g. how they deal with specific standard output, errors, or exceptions.

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