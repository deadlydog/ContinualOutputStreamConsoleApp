using System;
using System.Collections.Generic;
using System.Text;

namespace ContinualOutput
{
	public class ApplicationArguments
	{
		public bool ShouldDisplayApplicationHelpInstructions { get; }
		public int NumberOfMessagesToWrite { get; }
		public int NumberOfMillisecondsToRunFor { get; }
		public OutputTypes OutputType { get; }
		public string StandardOutputString { get; }
		public string StandardErrorString { get; }
		public int ExitCode { get; }
		public bool ShouldThrowException { get; }
		public string ExceptionMessage { get; }
		public int DelayBetweenMessagesInMilliseconds { get; }

		public ApplicationArguments(bool shouldDisplayApplicationHelpInstructions, int numberOfMessagesToWrite, int numberOfMillisecondsToRunFor, OutputTypes outputType, string standardOutputString, string standardErrorString, int exitCode, bool shouldThrowException, string exceptionMessage, int delayBetweenMessagesInMilliseconds)
		{
			ShouldDisplayApplicationHelpInstructions = shouldDisplayApplicationHelpInstructions;
			NumberOfMessagesToWrite = numberOfMessagesToWrite;
			NumberOfMillisecondsToRunFor = numberOfMillisecondsToRunFor;
			OutputType = outputType;
			StandardOutputString = standardOutputString ?? throw new ArgumentNullException(nameof(standardOutputString));
			StandardErrorString = standardErrorString ?? throw new ArgumentNullException(nameof(standardErrorString));
			ExitCode = exitCode;
			ShouldThrowException = shouldThrowException;
			ExceptionMessage = exceptionMessage ?? throw new ArgumentNullException(nameof(exceptionMessage)); ;
			DelayBetweenMessagesInMilliseconds = delayBetweenMessagesInMilliseconds;
		}
	}

	public enum OutputTypes
	{
		All,
		Output,
		Error
	}
}
