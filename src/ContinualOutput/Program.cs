using System;

namespace ContinualOutput
{
	class Program
	{
		static int Main(string[] args)
		{
			var runner = new ContinualOutputRunner(args);
			var exitCode = runner.Run();
			return exitCode;
		}
	}
}
