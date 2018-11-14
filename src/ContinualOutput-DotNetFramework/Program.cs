using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
