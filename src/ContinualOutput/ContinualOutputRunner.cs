using System;
using System.Collections.Generic;
using System.Text;

namespace ContinualOutput
{
	public class ContinualOutputRunner
	{
		private ApplicationArguments ApplicationArguments { get; }

		public ContinualOutputRunner(string[] args)
		{
			ApplicationArguments = ApplicationArgumentsParser.ParseApplicationArguments(args);
		}

		public int Run()
		{
			if (ApplicationArguments.ShouldDisplayApplicationHelpInstructions)
			{
				ApplicationArgumentsParser.DisplayHelpInstructions();
				return 0;
			}

			WriteMessagesUntilComplete();

			return ApplicationArguments.ExitCode;
		}

		private void WriteMessagesUntilComplete()
		{
			int numberOfMessagesWritten = 0;
			var startTime = DateTime.UtcNow;
			bool shouldContinueRunning = ShouldContinueRunning(ApplicationArguments, numberOfMessagesWritten, startTime);
			while (shouldContinueRunning)
			{
				numberOfMessagesWritten++;

				bool shouldWriteOutput = ApplicationArguments.OutputType == OutputTypes.Output || ApplicationArguments.OutputType == OutputTypes.All;
				if (shouldWriteOutput)
				{
					Console.WriteLine($"[{numberOfMessagesWritten}] " + ApplicationArguments.StandardOutputString);
				}

				bool shouldWriteError = ApplicationArguments.OutputType == OutputTypes.Error || ApplicationArguments.OutputType == OutputTypes.All;
				if (shouldWriteError)
				{
					Console.Error.WriteLine($"[{numberOfMessagesWritten}] " + ApplicationArguments.StandardErrorString);
				}

				System.Threading.Thread.Sleep(ApplicationArguments.DelayBetweenMessagesInMilliseconds);

				shouldContinueRunning = ShouldContinueRunning(ApplicationArguments, numberOfMessagesWritten, startTime);
			}
		}

		private bool ShouldContinueRunning(ApplicationArguments applicationArguments, int numberOfMessagesWritten, DateTime startTime)
		{
			if (applicationArguments.NumberOfMessagesToWrite > 0)
			{
				return numberOfMessagesWritten < applicationArguments.NumberOfMessagesToWrite;
			}
			else
			{
				var finishTime = startTime.AddMilliseconds(applicationArguments.NumberOfMillisecondsToRunFor);
				return DateTime.UtcNow < finishTime;
			}
		}
	}
}
