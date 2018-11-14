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
		public bool ShouldWriteErrors { get; }
		public string StandardOutputString { get; }
		public string StandardErrorString { get; }
		public int ExitCode { get; }
		public int DelayBetweenMessagesInMilliseconds { get; }

		public ApplicationArguments(bool shouldDisplayApplicationHelpInstructions, int numberOfMessagesToWrite, int numberOfMillisecondsToRunFor, bool shouldWriteErrors, string standardOutputString, string standardErrorString, int exitCode, int delayBetweenMessagesInMilliseconds)
		{
			ShouldDisplayApplicationHelpInstructions = shouldDisplayApplicationHelpInstructions;
			NumberOfMessagesToWrite = numberOfMessagesToWrite;
			NumberOfMillisecondsToRunFor = numberOfMillisecondsToRunFor;
			ShouldWriteErrors = shouldWriteErrors;
			StandardOutputString = standardOutputString ?? throw new ArgumentNullException(nameof(standardOutputString));
			StandardErrorString = standardErrorString ?? throw new ArgumentNullException(nameof(standardErrorString));
			ExitCode = exitCode;
			DelayBetweenMessagesInMilliseconds = delayBetweenMessagesInMilliseconds;
		}
	}
}
