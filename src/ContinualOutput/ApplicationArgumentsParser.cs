using System;
using System.Collections.Generic;
using System.Text;

namespace ContinualOutput
{
	public class ApplicationArgumentsParser
	{
		public static ApplicationArguments ParseApplicationArguments(string[] arguments)
		{
			bool shouldDisplayHelpInstructions = arguments == null || arguments.Length == 0;
			int numberOfMessagesToWrite = 0;
			int numberOfMillisecondsToRunFor = 0;
			OutputTypes outputType = OutputTypes.Output;
			string standardOutputString = "Default standard output message.";
			string standardErrorString = "Default standard error message.";
			int exitCode = 0;
			bool shouldThrowException = false;
			string exceptionMessage = "Default exception message.";
			int delayBetweenMessagesInMilliseconds = 1000;

			for (int index = 0; index < arguments.Length; index++)
			{
				var argument = arguments[index];
				var nextArgument = (index + 1 < arguments.Length) ? arguments[index + 1] : string.Empty;
				switch (argument.ToLower())
				{
					case "/n":
					case "/number": numberOfMessagesToWrite = int.Parse(nextArgument); index++;
						break;
					case "/t":
					case "/time": numberOfMillisecondsToRunFor = int.Parse(nextArgument); index++;
						break;
					case "/ot":
					case "/outputtype":
						switch (nextArgument.ToLower())
						{
							case "all": outputType = OutputTypes.All; break;
							case "error": outputType = OutputTypes.Error; break;
							default: outputType = OutputTypes.Output; break;
						}
						index++;
						break;
					case "/om":
					case "/outputmessage": standardOutputString = nextArgument; index++;
						break;
					case "/em":
					case "/errormessage": standardErrorString = nextArgument; index++;
						break;
					case "/ec":
					case "/exitcode": exitCode = int.Parse(nextArgument); index++;
						break;
					case "/te":
					case "/throwexception": shouldThrowException = true;
						break;
					case "/exm":
					case "/exceptionmessage": exceptionMessage = nextArgument; index++;
						break;
					case "/d":
					case "/delay": delayBetweenMessagesInMilliseconds = int.Parse(nextArgument); index++;
						break;
					default:
						Console.Error.WriteLine($"An invalid argument of '{argument}' was provided.");
						shouldDisplayHelpInstructions = true;
						break;
				}
			}

			var applicationArguments = new ApplicationArguments(
				shouldDisplayApplicationHelpInstructions: shouldDisplayHelpInstructions,
				numberOfMessagesToWrite: numberOfMessagesToWrite,
				numberOfMillisecondsToRunFor: numberOfMillisecondsToRunFor,
				outputType: outputType,
				standardOutputString: standardOutputString,
				standardErrorString: standardErrorString,
				exitCode: exitCode,
				shouldThrowException: shouldThrowException,
				exceptionMessage: exceptionMessage,
				delayBetweenMessagesInMilliseconds: delayBetweenMessagesInMilliseconds);
			return applicationArguments;
		}

		public static void DisplayHelpInstructions()
		{
			var instructions = @"
Usage: ContinualOutput.exe ([/number count] | [/time milliseconds]) [/outputType type] [/outputMessage message] [/errorMessage message] [/exitCode int] [/throwException message] [/delay milliseconds]

You must provide either the /number or /time argument. If both are provided, /time will be ignored.

Options (alias first):
	/n /number count	The number of output strings to be written before exiting.
	/t /time seconds	The number of milliseconds to run for before exiting.
	/ot /outputType type	Determines if only Standard Output, Standard Error, or both are written. Valid values are 'output', 'error', and 'all'. If not provided, the 'output' will be used.
	/om /outputMessage message	The string to write to the Standard Output stream. If not provided a default will be used.
	/em /errorMessage message	The string to write to the Standard Error stream. If not provided a default will be used.
	/ec /exitCode int	The number to return when the console app exits. If not provided, 0 will be returned. If /throwException is specified, this parameter is ignored.
	/te /throwException	Throws an exception that causes the application to exit. The exception is thrown after all messages have been written.
	/exm /exceptionMessage message	The string to use for the Exception's message when using the /throwException parameter. If not provided a default will be used.
	/d /delay int		The number of milliseconds to wait between output messages. If not provided, 1000 will be used.
";
			Console.WriteLine(instructions);
		}
	}
}
