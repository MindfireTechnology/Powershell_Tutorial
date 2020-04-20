using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SOLIDDemo.Web
{
	public class WebRequester : IDisposable
	{
		protected HttpClient Client { get; }
		private bool IsDisposing { get; set; }
		protected ILogger<WebRequester> Logger { get; }

		public WebRequester(ILogger<WebRequester> logger)
		{
			Client = new HttpClient();
			Logger = logger;
		}

		public async Task PostAsync(string url, string data)
		{
			using (var content = new StringContent(data))
			{
				var response = await Client.PostAsync(url, content);
				if (!response.IsSuccessStatusCode)
				{
					throw new InvalidOperationException("Web request failed");
				}
			}
		}

		public Task PostAsync<T>(string url, T data)
		{
			string content = JsonSerializer.Serialize<T>(data);
			return PostAsync(url, content);
		}

		protected virtual void Dispose(bool isDisposing)
		{
			if (IsDisposing)
				return;

			IsDisposing = isDisposing;

			Client.Dispose();

			GC.SuppressFinalize(true);
		}

		public void Dispose()
		{
			Dispose(true);
		}
	}
}
