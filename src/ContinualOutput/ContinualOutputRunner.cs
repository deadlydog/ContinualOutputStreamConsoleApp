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
			do
			{
				bool shouldWriteError = ApplicationArguments.ShouldWriteErrors && (numberOfMessagesWritten % 2 == 0);
				if (shouldWriteError)
				{
					Console.Error.WriteLine(ApplicationArguments.StandardErrorString);
				}
				else
				{
					Console.WriteLine(ApplicationArguments.StandardOutputString);
				}

				System.Threading.Thread.Sleep(ApplicationArguments.DelayBetweenMessagesInMilliseconds);

				numberOfMessagesWritten++;
				shouldContinueRunning = ShouldContinueRunning(ApplicationArguments, numberOfMessagesWritten, startTime);
			} while (shouldContinueRunning);
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
