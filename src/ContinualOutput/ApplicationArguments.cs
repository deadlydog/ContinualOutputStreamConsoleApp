using System;
using System.Collections.Generic;
using System.Text;

namespace ContinualOutput
{
	public class ApplicationArguments
	{
		public int NumberOfMessagesToWrite { get; }
		public int NumberOfSecondsToRunFor { get; }
		public bool ShouldWriteErrors { get; }
		public string StandardOutputString { get; }
		public string StandardErrorString { get; }
		public int ExitCode { get; }

		public ApplicationArguments(int numberOfMessagesToWrite, int numberOfSecondsToRunFor, bool shouldWriteErrors, string standardOutputString, string standardErrorString, int exitCode)
		{
			NumberOfMessagesToWrite = numberOfMessagesToWrite;
			NumberOfSecondsToRunFor = numberOfSecondsToRunFor;
			ShouldWriteErrors = shouldWriteErrors;
			StandardOutputString = standardOutputString ?? throw new ArgumentNullException(nameof(standardOutputString));
			StandardErrorString = standardErrorString ?? throw new ArgumentNullException(nameof(standardErrorString));
			ExitCode = exitCode;
		}
	}
}
