using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SOLID.Data;
using SOLID.Data.Implementation;
using System;

namespace SOLID.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			Procedural();
			//Modern();

		}

		static void Procedural()
		{
			var runner = new Procedural();
			runner.Run().Wait();
		}

		static void Modern()
		{
			var services = new ServiceCollection();
			ConfigureServices(services);
			var serviceProvider = services.BuildServiceProvider();

			var modern = serviceProvider.GetService<Modern>();
			modern.Run().Wait();
		}

		static void ConfigureServices(IServiceCollection services)
		{
			services.AddLogging(config =>
			{
				config.AddConsole();
			});

			services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
			services.AddSingleton<Modern>();
		}
	}
}
