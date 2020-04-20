using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SOLID.Data.Implementation
{
	public class Repository<T> : IRepository<T>
	{
		protected IEnumerable<T> Cache { get; set; }

		public Task<T> Get(int id)
		{
			return Task.FromResult(Cache.FirstOrDefault());
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			using (var file = File.OpenRead("data.json"))
			{
				var items = await JsonSerializer.DeserializeAsync<IEnumerable<T>>(file);
				Cache = items;
				return items;
			}
		}
	}
}
