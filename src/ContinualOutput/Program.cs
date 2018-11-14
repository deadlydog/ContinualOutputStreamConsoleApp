using System;

namespace ContinualOutput
{
	class Program
	{
		static void Main(string[] args)
		{
			var runner = new ContinualOutputRunner(args);
			runner.Run();
		}
	}
}
