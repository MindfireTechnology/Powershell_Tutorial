using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SOLIDDemo.Data;
using SOLIDDemo.Data.Implementation;
using SOLIDDemo.Web;
using System;

namespace SOLIDDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			
		}

		static void RunBad()
		{
			new FileProcessor().Run().Wait();
		}

		static void RunGood()
		{
			var services = new ServiceCollection();
			ConfigureServices(services);
			var container = services.BuildServiceProvider();
			var processor = container.GetService<Processor>();
			processor.Run().Wait();
		}

		static void ConfigureServices(IServiceCollection services)
		{
			services.AddLogging(config =>
			{
				config.AddConsole();
			});
			services.AddSingleton<WebRequester>();
			services.AddTransient<Processor>();
			services.AddSingleton(typeof(IRepository<>), provider =>
			{
				string path = "data.json";
				return new Repository(path);
			});
		}
	}
}
