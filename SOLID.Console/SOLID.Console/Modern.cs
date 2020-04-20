using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Console
{
	public class Modern
	{
		public ILogger<Modern> Logger { get; }

		public Modern(ILogger<Modern> logger)
		{
			Logger = logger;
		}

		public async Task Run()
		{

		}
	}
}
