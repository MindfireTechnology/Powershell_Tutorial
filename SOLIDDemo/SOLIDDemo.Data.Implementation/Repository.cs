using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace SOLIDDemo.Data.Implementation
{
	public class Repository<T> : IRepository<T>
	{
		public string FilePath { get; }

		public Repository(string filePath)
		{
			FilePath = filePath;
		}

		public Task<T> Get(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			using (var file = File.OpenRead(FilePath))
			{
				var data = await JsonSerializer.DeserializeAsync<IEnumerable<T>>(file);
				return data;
			}
		}

		public Task Insert(T data)
		{
			throw new NotImplementedException();
		}
	}
}
