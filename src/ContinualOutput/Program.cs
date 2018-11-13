using System;

namespace ContinualOutput
{
	class Program
	{
		static void Main(string[] args)
		{
			bool shouldDisplayHelpInstructions = args.Length == 0 || args[0] == "/?" || args[0].Contains("Help", StringComparison.OrdinalIgnoreCase);
			if (shouldDisplayHelpInstructions)
			{
				DisplayHelpInstructions();
				return;
			}

			var applicationArguments = ParseApplicationArguments(args);

			int numberOfMessagesWritten = 0;
			var startTime = DateTime.UtcNow;
			bool shouldContinueRunning = ShouldContinueRunning(applicationArguments, numberOfMessagesWritten, startTime);
			do
			{
				bool shouldWriteError = applicationArguments.ShouldWriteErrors && (numberOfMessagesWritten % 2 == 0);
				if (shouldWriteError)
				{
					Console.Error.WriteLine(applicationArguments.StandardErrorString);
				}
				else
				{
					Console.WriteLine(applicationArguments.StandardOutputString);
				}

				numberOfMessagesWritten++;
				shouldContinueRunning = ShouldContinueRunning(applicationArguments, numberOfMessagesWritten, startTime);
			} while (shouldContinueRunning);
			
		}

		private static bool ShouldContinueRunning(ApplicationArguments applicationArguments, int numberOfMessagesWritten, DateTime startTime)
		{
			if (applicationArguments.NumberOfMessagesToWrite > 0)
			{
				return numberOfMessagesWritten < applicationArguments.NumberOfMessagesToWrite;
			}
			else
			{
				var finishTime = startTime.AddSeconds(applicationArguments.NumberOfSecondsToRunFor);
				return DateTime.UtcNow < finishTime;
			}
		}

		private static ApplicationArguments ParseApplicationArguments(string[] arguments)
		{
			int numberOfMessagesToWrite = 0;
			int numberOfSecondsToRunFor = 0;
			bool shouldWriteErrors = false;
			string standardOutputString = "Default standard output message.";
			string standardErrorString = "Default standard error message.";
			int exitCode = 0;

			for (int index = 0; index < arguments.Length; index++)
			{
				var argument = arguments[index];
				var nextArgument = (index + 1 < arguments.Length) ? arguments[index + 1] : string.Empty;
				switch (argument.ToLower())
				{
					case "/number": numberOfMessagesToWrite = int.Parse(nextArgument); break;
					case "/time": numberOfSecondsToRunFor = int.Parse(nextArgument); break;
					case "/writeErrors": shouldWriteErrors = true; break;
					case "/output": standardOutputString = nextArgument; break;
					case "/error": standardErrorString = nextArgument; break;
					case "/exitCode": exitCode = int.Parse(nextArgument); break;
					default:
						throw new ArgumentException($"An invalid argument of '{argument}' was provided.");
				}
			}

			var applicationArguments = new ApplicationArguments(
				numberOfMessagesToWrite: numberOfMessagesToWrite,
				numberOfSecondsToRunFor: numberOfSecondsToRunFor,
				shouldWriteErrors: shouldWriteErrors,
				standardOutputString: standardOutputString,
				standardErrorString: standardErrorString,
				exitCode: exitCode);
			return applicationArguments;
		}

		public static void DisplayHelpInstructions()
		{
			var instructions = @"
Usage: ContinualOutput .exe ([/number count] | [/time seconds]) [/writeErrors] [/output string] [/error string] [/exitCode int]

You must provide either the /number or /time argument. If both are provided, /time will be ignored.

Options:
	/number count	The number of output strings to be written before exiting.
	/time seconds	The number of seconds to run for before exiting.
	/writeErrors	Randomly return a message on the Standard Error stream instead of the Standard Output stream.
	/output string	The string to write to the Standard Output stream. If not provided a default will be used.
	/error string	The string to write to the Standard Error stream. If not provided a default will be used.
	/exitCode int	The number to return when the console app exits. If not provided, 0 will be returned.
";
			Console.WriteLine(instructions);
		}
	}
}
