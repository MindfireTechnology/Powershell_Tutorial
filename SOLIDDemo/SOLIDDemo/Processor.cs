using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SOLIDDemo.Data;
using SOLIDDemo.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDDemo
{
	public class Processor
	{
		public ILogger<Processor> Logger { get; }
		public WebRequester Requester { get; }
		public IRepository<User> UserRepository { get; }
		public IOptions<EnvironmentSettings> Options { get; }

		public Processor(ILogger<Processor> logger, WebRequester requester,
			IRepository<User> userRepository, IOptions<EnvironmentSettings> options)
		{
			Logger = logger;
			Requester = requester;
			UserRepository = userRepository;
			Options = options;
		}

		public async Task Run()
		{
			Logger.LogInformation("Starting processing");
			var users = await UserRepository.GetAll();
			Logger.LogInformation("Read users");

			// TODO: processing
			await Process();

			foreach(var user in users)
			{
				try
				{
					Logger.LogInformation($"Sending {user.FirstName} {user.LastName} to the server");
					await Requester.PostAsync(Options.Value.ApiUrl, user);
				} catch (InvalidOperationException ioe)
				{
					Logger.LogError(ioe, "Error sending user to server");
					break;
				}
			}
		}

		public async Task Process()
		{

		}
	}
}
