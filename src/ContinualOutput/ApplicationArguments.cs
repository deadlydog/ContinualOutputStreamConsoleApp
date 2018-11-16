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
		public int DelayBetweenMessagesInMilliseconds { get; }

		public ApplicationArguments(bool shouldDisplayApplicationHelpInstructions, int numberOfMessagesToWrite, int numberOfMillisecondsToRunFor, OutputTypes outputType, string standardOutputString, string standardErrorString, int exitCode, int delayBetweenMessagesInMilliseconds)
		{
			ShouldDisplayApplicationHelpInstructions = shouldDisplayApplicationHelpInstructions;
			NumberOfMessagesToWrite = numberOfMessagesToWrite;
			NumberOfMillisecondsToRunFor = numberOfMillisecondsToRunFor;
			OutputType = outputType;
			StandardOutputString = standardOutputString ?? throw new ArgumentNullException(nameof(standardOutputString));
			StandardErrorString = standardErrorString ?? throw new ArgumentNullException(nameof(standardErrorString));
			ExitCode = exitCode;
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
