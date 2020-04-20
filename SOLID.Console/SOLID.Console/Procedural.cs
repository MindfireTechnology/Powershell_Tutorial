using SOLID.Console.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SOLID.Console
{
	public class Procedural
	{
		public async Task Run()
		{
			System.Console.WriteLine("Reading new users");
			using (var file = File.OpenRead("data.json"))
			{
				var items = await JsonSerializer.DeserializeAsync<IEnumerable<User>>(file);
				string url = new UriBuilder
				{
					Host = "localhost",
					Port = 8080,
					Path = "/Users"
				}.ToString();

				foreach(var item in items)
				{
					System.Console.WriteLine($"Sending {item.FirstName} {item.LastName} to the server.");
					string data = Encoding.UTF8.GetString(JsonSerializer.SerializeToUtf8Bytes<User>(item));
					using (var client = new HttpClient())
					using (var content = new StringContent(data))
					{
						var response = await client.PostAsync(url, content);
						if (!response.IsSuccessStatusCode)
						{
							System.Console.WriteLine($"Error sending data to the server. {response.ReasonPhrase}");
							break;
						}
					}
				}
			}
		}
	}
}
