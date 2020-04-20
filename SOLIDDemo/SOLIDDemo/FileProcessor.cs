using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http;

namespace SOLIDDemo
{
	public class FileProcessor
	{
		public async Task Run()
		{
			Console.WriteLine("Opening file");
			using (var file = File.OpenRead("data.json"))
			{
				var users = await JsonSerializer.DeserializeAsync<IEnumerable<User>>(file);
				Console.WriteLine("Deserialzied Content");

				string url = new UriBuilder
				{
					Host = "localhost",
					Port = 8080,
					Path = "Users",
					Scheme = "http"
				}.ToString();

				using (var client = new HttpClient())
				{
					foreach (var user in users)
					{
						Console.WriteLine($"Sending {user.FirstName} {user.LastName} to the server.");
						string data = JsonSerializer.Serialize<User>(user);

						using (var content = new StringContent(data))
						{
							var response = await client.PostAsync(url, content);
							if (!response.IsSuccessStatusCode)
							{
								Console.WriteLine($"Error sending user to server. {response.ReasonPhrase}: {response.RequestMessage}");
								break;
							}
						}
					}
				}
			}
		}
	}
}
